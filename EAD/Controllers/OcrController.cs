using AutoMapper;
using ClosedXML.Excel;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EAD.Attributes;
using EAD.Data.Enums;
using EAD.Data.Structures;
using EAD.Extensions;
using EAD.Helpers;
using EAD.Interfaces.Services;
using EAD.Models;
using EAD.Processors;
using EAD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Controllers
{
    public class OcrController : BaseController
    {
        public OcrController(IUnitOfWork uow, IHttpContextAccessor httpContext, IMapper mapper, IStringLocalizer<NotificationsHelper> notify)
            : base(typeof(OcrController), uow, httpContext, mapper, notify)
        {
        }

        /// <summary>
        /// Deleting OCR configuration from the database
        /// </summary>
        /// <param name="key">Configuration ID</param>
        [Authorize]
        [HttpGet("/Ocr/Delete")]
        public async Task<IActionResult> Delete(int key)
        {
            if (!User.IsInRole(PermissionsType.IsManager))
            {
                return BadRequest(_notify.GetValue(NotificationsHelper.NoPermissionWarning));
            }

            OcrConfiguration configuration = await _uow.OcrConfigurationsRepository.GetById(key);
            if (configuration == null)
            {
                _logger.Warn($"OCR configuration not found [Id = {key}]");
                return BadRequest(_notify.GetValue(NotificationsHelper.OcrConfigurationNotFoundWarning));
            }

            bool isFtpDeleted = true;
            if (configuration.FtpConfiguration != null)
            {
                int ftpId = configuration.FtpConfiguration.Id;
                _uow.FtpConfigurationsRepository.Delete(configuration.FtpConfiguration);
                if (await _uow.SaveChanges() > 0)
                {
                    _logger.Info($"FTP configuration successfully deleted [Id = {ftpId}]");
                }
                else
                {
                    isFtpDeleted = false;
                    _logger.Warn($"An error occurred while trying to remove the FTP configuration [Id = {ftpId}]");
                }
            }

            _uow.OcrConfigurationsRepository.Delete(configuration);

            if (!isFtpDeleted || await _uow.SaveChanges() <= 0)
            {
                _logger.Warn($"An error occurred while trying to remove the OCR configuration [Id = {key}, Nazwa = '{configuration.Name}']");
                return BadRequest(_notify.GetValue(NotificationsHelper.OcrConfigurationDeleteWarning));
            }

            _logger.Info($"OCR configuration successfully deleted [Id = {key}, Nazwa = '{configuration.Name}']");
            return Ok(_notify.GetValue(NotificationsHelper.OcrConfigurationDeleteSuccess));
        }

        /// <summary>
        /// Exporting configuration to an Excel file
        /// </summary>
        [Authorize]
        [HttpGet("/Ocr/ExportToExcel/")]
        public async Task<IActionResult> ExportToExcel()
        {
            Language language = Request.GetLanguage();

            DataTable dt = ExcelProcessor.CreateTable((await _uow.OcrConfigurationsRepository.GetAll()).Select(x => x.ToViewModel()).OrderBy(x => x.Name), language);

            using XLWorkbook wb = new();
            wb.Worksheets.Add(dt);

            using MemoryStream stream = new();
            wb.SaveAs(stream);

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ExcelProcessor.GetOutputFileName(language));
        }

        /// <summary>
        /// Getting list of OCR configurations
        /// </summary>
        /// <param name="loadOptions">dxDataGrid load options</param>
        [Authorize]
        [HttpGet("/Ocr/Get")]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            IEnumerable<OcrConfigurationViewModel> viewModels = new List<OcrConfigurationViewModel>();

            try
            {
                viewModels = (await _uow.OcrConfigurationsRepository.GetAll()).Select(x => x.ToViewModel());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return DataSourceLoader.Load(viewModels, loadOptions);
        }

        /// <summary>
        /// Getting all OCR configurations
        /// </summary>
        [ApiKey]
        [AllowAnonymous]
        [HttpGet("/Ocr/GetAll")]
        public async Task<List<OcrConfiguration>> GetAll()
        {
            return await _uow.OcrConfigurationsRepository.GetAll();
        }

        /// <summary>
        /// Importing OCR configurations from an Excel file
        /// </summary>
        /// <param name="file">Excel file</param>
        [Authorize]
        [HttpPost("/Ocr/ImportFromFile")]
        public async Task<IActionResult> ImportFromFile(IFormFile file)
        {
            if (!User.IsInRole(PermissionsType.IsManager))
            {
                return BadRequest(_notify.GetValue(NotificationsHelper.NoPermissionWarning));
            }

            int counter = 0;
            RemoteFile remoteFile = await FilesProcessor.SaveFile(file, $"{GlobalConfig.RootDirectory}\\files\\temp");
            if (remoteFile.IsValid())
            {
                DataTable dataTable = ExcelReadHelper.GetDataTable(remoteFile.Path);
                if (dataTable.Rows.Count > 0)
                {
                    IEnumerable<ColumnNamesSettings> columnNamesSettings = typeof(OcrConfigurationViewModel).GetColumnNames();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        OcrConfigurationViewModel viewModel = dataRow.ToObject<OcrConfigurationViewModel>(columnNamesSettings);

                        FtpConfiguration ftpConfiguration = new();
                        _mapper.Map(viewModel, ftpConfiguration);

                        OcrConfiguration ocrConfiguration = new();
                        _mapper.Map(viewModel, ocrConfiguration);

                        ocrConfiguration.CreatedById = User.GetString("DisplayName");
                        ocrConfiguration.CreatedDate = DateTime.Now;

                        if (!ocrConfiguration.IsValid())
                        {
                            continue;
                        }

                        if (ftpConfiguration.IsValid())
                        {
                            _uow.FtpConfigurationsRepository.Add(ftpConfiguration);
                            if (await _uow.SaveChanges() <= 0)
                            {
                                _logger.Warn($"An error occurred while trying to add a new FTP configuration [Host = '{ftpConfiguration.Host}', Port = {ftpConfiguration.Port}, SFTP = {(ftpConfiguration.IsSFTP ? "Yes" : "No")}]");
                            }
                            else
                            {
                                ocrConfiguration.FtpConfigurationId = ftpConfiguration.Id;
                                _logger.Info($"New FTP configuration successfully added [Id = {ftpConfiguration.Id}]");
                            }
                        }

                        _uow.OcrConfigurationsRepository.Add(ocrConfiguration);
                        if (await _uow.SaveChanges() > 0)
                        {
                            counter++;

                            _logger.Info($"New OCR configuration successfully added [Nazwa = '{ocrConfiguration.Name}']");
                        }
                        else
                        {
                            _logger.Warn($"An error occurred while trying to add a new OCR configuration [Nazwa = '{ocrConfiguration.Name}']");
                        }
                    }
                }

                if (FilesProcessor.Delete(remoteFile.Path))
                {
                    _logger.Info($"Temporary file successfully deleted [Path = '{remoteFile.Path}']");
                }
                else
                {
                    _logger.Warn($"An error occurred while trying to delete the temporary file [Path = '{remoteFile.Path}']");
                }
            }

            return counter <= 0
                ? BadRequest(_notify.GetValue(NotificationsHelper.ImportFromFileWarning))
                : Ok(_notify.GetValue(NotificationsHelper.ImportFromFileSuccess));
        }

        /// <summary>
        /// OCR configurations page
        /// </summary>
        [Authorize]
        [HttpGet("/Ocr")]
        [HttpGet("/Ocr/Index")]
        public IActionResult Index()
        {
            CookieHelper.SetValue(Response, "LastPageUrl", "/Ocr");

            return View();
        }

        /// <summary>
        /// Adding new OCR configuration
        /// </summary>
        /// <param name="values">OCR configurations as JSON</param>
        [Authorize]
        [HttpGet("/Ocr/Post")]
        public async Task<IActionResult> Post(string values)
        {
            if (!User.IsInRole(PermissionsType.IsManager))
            {
                return BadRequest(_notify.GetValue(NotificationsHelper.NoPermissionWarning));
            }

            OcrConfiguration configuration = new();
            _mapper.Map(values.FromJson<OcrConfigurationViewModel>(), configuration);

            configuration.CreatedById = User.GetString("DisplayName");
            configuration.CreatedDate = DateTime.Now;
            if (!configuration.IsValid())
            {
                _logger.Warn("Incorrect OCR configuration while adding");
                return BadRequest(_notify.GetValue(NotificationsHelper.InvalidModelWarning));
            }

            _uow.OcrConfigurationsRepository.Add(configuration);
            if (await _uow.SaveChanges() <= 0)
            {
                _logger.Warn($"An error occurred while trying to add a new OCR configuration [Name = '{configuration.Name}']");
                return BadRequest(_notify.GetValue(NotificationsHelper.OcrConfigurationAddWarning));
            }

            await AddFtpConfiguration(configuration, values);

            _logger.Info($"New OCR configuration successfully added [Name = '{configuration.Name}']");
            return Ok(_notify.GetValue(NotificationsHelper.OcrConfigurationAddSuccess));
        }

        /// <summary>
        /// Updating the OCR configuration
        /// </summary>
        /// <param name="key">OCR configuration ID</param>
        /// <param name="values">OCR configuration as JSON</param>
        [Authorize]
        [HttpGet("/Ocr/Put")]
        public async Task<IActionResult> Put(int key, string values)
        {
            if (!User.IsInRole(PermissionsType.IsManager))
            {
                return BadRequest(_notify.GetValue(NotificationsHelper.NoPermissionWarning));
            }

            OcrConfigurationViewModel changes = values.FromJson<OcrConfigurationViewModel>();
            OcrConfiguration configuration = await _uow.OcrConfigurationsRepository.GetById(key);
            if (configuration == null)
            {
                _logger.Warn($"OCR configuration not found [Id = {key}]");
                return BadRequest(_notify.GetString(NotificationsHelper.OcrConfigurationNotFoundWarning));
            }

            if (configuration.FtpConfigurationId == null)
            {
                await AddFtpConfiguration(configuration, values);
            }
            else
            {
                FtpConfiguration ftpConfiguration = await _uow.FtpConfigurationsRepository.GetById(configuration.FtpConfigurationId.Value);
                if (ftpConfiguration != null)
                {
                    _mapper.Map(changes, ftpConfiguration);

                    _uow.FtpConfigurationsRepository.Update(ftpConfiguration);

                    if (await _uow.SaveChanges() > 0)
                    {
                        _logger.Info($"FTP configuration successfully updated [Id = {ftpConfiguration.Id}]");
                    }
                    else
                    {
                        _logger.Warn($"An error occurred while trying to update the FTP configuration [Id = {ftpConfiguration.Id}]");
                    }
                }
            }

            configuration.UpdatedById = User.GetString("DisplayName");
            configuration.UpdatedDate = DateTime.Now;
            _mapper.Map(changes, configuration);
            _uow.OcrConfigurationsRepository.Update(configuration);

            if (await _uow.SaveChanges() <= 0)
            {
                _logger.Warn($"An error occurred while trying to update the OCR configuration [Id = {key}]");
                return BadRequest(_notify.GetValue(NotificationsHelper.OcrConfigurationUpdateWarning));
            }

            _logger.Info($"The OCR configuration was successfully updated [Id = {key}]");
            return Ok(_notify.GetValue(NotificationsHelper.OcrConfigurationUpdateSuccess));
        }

        /// <summary>
        /// Adding configuration to the database
        /// </summary>
        /// <param name="configuration">OCR configurations</param>
        /// <param name="values">Configuration as JSON</param>
        private async Task AddFtpConfiguration(OcrConfiguration configuration, string values)
        {
            if (configuration != null && !string.IsNullOrEmpty(values))
            {
                FtpConfiguration ftpConfiguration = values.FromJson<FtpConfiguration>();
                if (ftpConfiguration.IsValid())
                {
                    _uow.FtpConfigurationsRepository.Add(ftpConfiguration);
                    if (await _uow.SaveChanges() > 0)
                    {
                        _logger.Info($"New FTP configuration successfully added [Id = {ftpConfiguration.Id}]");
                        configuration.FtpConfigurationId = ftpConfiguration.Id;
                        _uow.OcrConfigurationsRepository.Update(configuration);

                        if (await _uow.SaveChanges() > 0)
                        {
                            _logger.Info($"Successfully assigned FTP configuration to OCR configuration [Id = {configuration.Id}]");
                        }
                        else
                        {
                            _logger.Warn($"An error occurred while trying to assign an FTP configuration to an OCR configuration [Id = {configuration.Id}]");
                        }
                    }
                    else
                    {
                        _logger.Warn($"An error occurred while trying to add a new FTP configuration [Host = '{ftpConfiguration.Host}', Port = {ftpConfiguration.Port}, SFTP = {(ftpConfiguration.IsSFTP ? "Yes" : "No")}]");
                    }
                }
            }
        }
    }
}

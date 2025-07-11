using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EAD.Data.Enums;
using EAD.Extensions;
using EAD.Helpers;
using EAD.Interfaces.Services;
using EAD.Processors;
using EAD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EAD.Controllers
{
    public class PreviewController : BaseController
    {
        public PreviewController(IUnitOfWork uow, IHttpContextAccessor httpContext, IMapper mapper, IStringLocalizer<NotificationsHelper> notify)
            : base(typeof(PreviewController), uow, httpContext, mapper, notify)
        {
        }

        /// <summary>
        /// Deleting the file
        /// </summary>
        /// <param name="key">File's ID</param>
        [Authorize]
        [HttpGet("/Preview/Delete")]
        public IActionResult Delete(string key)
        {
            try
            {
                if (!User.IsInRole(PermissionsType.IsManager))
                {
                    return Ok(_notify.GetValue(NotificationsHelper.NoPermissionWarning));
                }

                if (!System.IO.File.Exists(key))
                {
                    _logger.Warn($"File does not exist [Path = '{key}']");
                    return BadRequest(_notify.GetValue(NotificationsHelper.BarcodeFileNotFoundWarning));
                }

                if (!FilesProcessor.Delete(key))
                {
                    _logger.Warn($"An error occurred while deleting the file [Path = '{key}']");
                    return BadRequest(_notify.GetValue(NotificationsHelper.BarcodeFileDeleteWarning));
                }

                _logger.Info($"The file was successfully deleted [Path = '{key}']");
                return Ok(_notify.GetValue(NotificationsHelper.BarcodeFileDeleteSuccess));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest(_notify.GetValue(NotificationsHelper.BarcodeFileDeleteWarning));
            }
        }

        /// <summary>
        /// Getting recognized files
        /// </summary>
        /// <param name="loadOptions">dxDataGrid load options</param>
        [Authorize]
        [HttpGet("/Preview/GetRecognizedFiles")]
        public object GetRecognizedFiles(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(FilesProcessor.GetBarcodeFileViewModels(DirectoryType.Recognized), loadOptions);
        }

        /// <summary>
        /// Getting unrecognied files
        /// </summary>
        /// <param name="loadOptions">dxDataGrid load options</param>
        [Authorize]
        [HttpGet("/Preview/GetUnrecognizedFiles")]
        public object GetUnrecognizedFiles(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(FilesProcessor.GetBarcodeFileViewModels(DirectoryType.Unrecognized), loadOptions);
        }

        /// <summary>
        /// Files preview page
        /// </summary>
        [Authorize]
        [HttpGet("/Preview")]
        [HttpGet("/Preview/Index")]
        public IActionResult Index()
        {
            CookieHelper.SetValue(Response, "LastPageUrl", "/Preview");

            return View();
        }

        /// <summary>
        /// Updating the file's info
        /// </summary>
        /// <param name="key">File's ID</param>
        /// <param name="values">File's data as JSON</param>
        [Authorize]
        [HttpGet("/Preview/Update")]
        public async Task<IActionResult> Update(string key, string values)
        {
            try
            {
                BarcodeFileViewModel barcodeFile = key.ToBarcodeFile(DirectoryType.Unprocessed);
                _mapper.Map(values.FromJson<BarcodeFileViewModel>(), barcodeFile);

                if (!System.IO.File.Exists(key))
                {
                    _logger.Warn($"File does not exist [Path = '{key}']");
                    return BadRequest(_notify.GetValue(NotificationsHelper.BarcodeFileNotFoundWarning));
                }

                var retryCounter = 1;
                try
                {
                    return await UpdateBarcode(key, barcodeFile);
                }
                catch (IOException ex)
                {
                    if (retryCounter <= GlobalConfig.MaxRetryCounter)
                    {
                        retryCounter++;
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        return await UpdateBarcode(key, barcodeFile);
                    }
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest(_notify.GetValue(NotificationsHelper.BarcodeFileUpdateWarning));
            }
        }

        /// <summary>
        /// Updating the barcode
        /// </summary>
        /// <param name="key">Input file payh</param>
        /// <param name="viewModel">Barcode data model</param>
        private async Task<IActionResult> UpdateBarcode(string key, BarcodeFileViewModel viewModel)
        {
            string outputFileName = $@"{GlobalConfig.GetDirectory(DirectoryType.Recognized).TrimEnd('\\')}\{viewModel.OrgUnit}_{viewModel.Date:yyyyMMddHHmmss}_{viewModel.Barcode}.pdf";
            string tempFileName = $@"{GlobalConfig.GetDirectory(DirectoryType.Recognized).TrimEnd('\\')}\{viewModel.OrgUnit}_{viewModel.Date:yyyyMMddHHmmss}_{viewModel.Barcode}_TEMP.pdf";
            await PdfProcessor.MergeFiles(new List<string> { key, outputFileName }, tempFileName);
            if (!System.IO.File.Exists(tempFileName))
            {
                _logger.Warn($"An error occurred while creating the temporary file [Path = '{tempFileName}']");
                return BadRequest(_notify.GetValue(NotificationsHelper.BarcodeFileUpdateWarning));
            }

            System.IO.File.Move(tempFileName, outputFileName, true);
            _ = FilesProcessor.Delete(key);
            _logger.Info($"Merged PDF files successfully [Path = '{outputFileName}']");
            return Ok(_notify.GetValue(NotificationsHelper.BarcodeFileUpdateSuccess));
        }
    }
}

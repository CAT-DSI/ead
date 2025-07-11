using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EAD.Extensions;
using EAD.Helpers;
using EAD.Interfaces.Services;
using EAD.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Controllers
{
    public class LogsPreviewController : BaseController
    {
        public LogsPreviewController(IUnitOfWork uow, IHttpContextAccessor httpContext, IMapper mapper, IStringLocalizer<NotificationsHelper> notify)
            : base(typeof(LogsPreviewController), uow, httpContext, mapper, notify)
        {
        }

        /// <summary>
        /// Getting preview logs
        /// </summary>
        /// <param name="startDate">Filter start date</param>
        /// <param name="endDate">Filter end date</param>
        /// <param name="loadOptions">dxDataGrid load options</param>
        [Authorize]
        [HttpGet("/LogsPreview/Get")]
        public async Task<object> Get(DateTime startDate, DateTime endDate, DataSourceLoadOptions loadOptions)
        {
            try
            {
                return DataSourceLoader.Load((await _uow.FtpResultsRepository.GetByDates(startDate, endDate)).Select(x => x.ToViewModel()), loadOptions);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return DataSourceLoader.Load(Array.Empty<FtpResultViewModel>(), loadOptions);
        }

        /// <summary>
        /// Logs preview page
        /// </summary>
        [Authorize]
        [HttpGet("/LogsPreview")]
        [HttpGet("/LogsPreview/Index")]
        public IActionResult Index()
        {
            CookieHelper.SetValue(Response, "LastPageUrl", "/LogsPreview");

            return View();
        }
    }
}

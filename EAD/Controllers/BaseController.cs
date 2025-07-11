using AutoMapper;
using EAD.Data.Enums;
using EAD.Extensions;
using EAD.Helpers;
using EAD.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NLog;
using System;

namespace EAD.Controllers
{
    public class BaseController : Controller
    {
        public readonly IHttpContextAccessor _httpContext;

        public readonly Language _language;

        public readonly ILogger _logger;

        public readonly IMapper _mapper;

        public readonly IStringLocalizer<NotificationsHelper> _notify;

        public readonly IUnitOfWork _uow;

        public BaseController(Type controllerType, IUnitOfWork uow, IHttpContextAccessor httpContext, IMapper mapper, IStringLocalizer<NotificationsHelper> notify)
        {
            _logger = LogManager.GetLogger(controllerType.FullName, controllerType);
            _uow = uow;
            _httpContext = httpContext;
            _mapper = mapper;
            _notify = notify;
            _language = _httpContext.HttpContext.Request.GetLanguage();

            var urlPath = _httpContext.HttpContext.Request.Path;
            if (!urlPath.Value.Contains("/Ocr/GetAll", StringComparison.OrdinalIgnoreCase) && !urlPath.Value.Contains("/FtpResults/Post", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(_httpContext.HttpContext.Request.GetCookie(CookieRequestCultureProvider.DefaultCookieName)))
                {
                    _httpContext.HttpContext.Response.SetLanguage(_language.ToLanguageId());

                    string referer = _httpContext.HttpContext.Request.GetReferer();
                    if (string.IsNullOrEmpty(referer))
                    {
                        referer = "/Home/LogIn";
                    }

                    _httpContext.HttpContext.Response.Redirect(referer, true);
                }
            }
        }

        /// <summary>
        /// SID of current logged in user
        /// </summary>
        public string UserSid => User.Identity.Name;

        /// <summary>
        /// Redirect to Access Denied page
        /// </summary>
        public IActionResult GoToAccessDenied()
        {
            return Redirect("/Home/AccessDenied");
        }

        /// <summary>
        /// Redirects to last visited page
        /// </summary>
        public IActionResult RedirectToLastPage()
        {
            string lastPageUrl = CookieHelper.GetValue(Request, "LastPageUrl");

            return Redirect(!string.IsNullOrEmpty(lastPageUrl) && Url.IsLocalUrl(lastPageUrl) ? lastPageUrl : "/Preview");
        }
    }
}

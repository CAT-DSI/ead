using AutoMapper;
using DevExtreme.AspNet.Mvc;
using EAD.Data.Enums;
using EAD.Extensions;
using EAD.Helpers;
using EAD.Interfaces.Services;
using EAD.Models;
using EAD.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Concurrent;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EAD.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IActiveDirectoryService _adService;

        private readonly IStringLocalizer<LogInResult> _logInResult;

        public HomeController(IUnitOfWork uow, IHttpContextAccessor httpContext, IMapper mapper, IStringLocalizer<NotificationsHelper> notify, IActiveDirectoryService adService, IStringLocalizer<LogInResult> logInResult)
            : base(typeof(HomeController), uow, httpContext, mapper, notify)
        {
            _adService = adService;
            _logInResult = logInResult;
        }

        /// <summary>
        /// Access Denied page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("/Home/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// Changing page language
        /// </summary>
        /// <param name="culture">New language</param>
        [Authorize]
        [HttpGet("/Home/Changelanguage")]
        public IActionResult Changelanguage(string culture = "en-US")
        {
            Response.SetLanguage(culture);

            return Redirect(Request.GetReferer());
        }

        /// <summary>
        /// Home page
        /// </summary>
        [Authorize]
        [HttpGet("/")]
        [HttpGet("/Home")]
        [HttpGet("/Home/Index")]
        public IActionResult Index()
        {
            return RedirectToLastPage();
        }

        /// <summary>
        /// Login page
        /// </summary>
        [AllowAnonymous]
        [HttpGet("/Home/LogIn")]
        public IActionResult LogIn()
        {
            return View(new LogInViewModel(_httpContext.HttpContext.Request));
        }

        /// <summary>
        /// Login action
        /// </summary>
        /// <param name="logIn">Login info data</param>
        [AllowAnonymous]
        [HttpPost("/Home/LogIn")]
        public async Task<IActionResult> LogIn(LogInViewModel logIn)
        {
            Domain domain = GlobalConfig.Domains.FirstOrDefault(x => x.Path == logIn.Domain);

            LogInResult logInResult = _adService.ValidateCredentials(domain, logIn);

            UserInfo userInfo = GetUserInfo(domain, logIn);

            if (userInfo == null)
            {
                TempData.SetNotification(ToastType.Error, _logInResult["Error"].Value.ToUnicode());

                return Redirect("/Home/LogIn");
            }
            else
            {
                if (logInResult == LogInResult.Success)
                {
                    CookieHelper.SetValue(Response, "Domain", logIn.Domain);
                    CookieHelper.SetValue(Response, "UserName", logIn.UserName);

                    return await LogInUser(userInfo, domain);
                }
                else
                {
                    TempData.SetNotification(logInResult == LogInResult.Error ? ToastType.Error : ToastType.Warning, _logInResult[logInResult.ToString()].Value.ToUnicode());

                    return Redirect("/Home/LogIn");
                }
            }
        }

        /// <summary>
        /// Logout action
        /// </summary>
        [Authorize]
        [HttpGet("/Home/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            CookieHelper.Clear(Request, Response);

            return Redirect("/Home/LogIn");
        }

        /// <summary>
        /// Getting user info from Active Directory
        /// </summary>
        /// <param name="domain">Login domain</param>
        /// <param name="logIn">Login info data</param>
        private UserInfo GetUserInfo(Domain domain, LogInViewModel logIn)
        {
            return domain != null && logIn != null
                ? _adService.GetUser(domain, logIn.UserName, logIn.UserName.EndsWith("@") ? IdentityType.UserPrincipalName : IdentityType.SamAccountName)
                : null;
        }

        /// <summary>
        /// User login process
        /// </summary>
        /// <param name="userInfo">User info</param>
        /// <param name="domain">Login domain</param>
        private async Task<IActionResult> LogInUser(UserInfo userInfo, Domain domain)
        {
            ConcurrentBag<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, userInfo?.ObjectSid),
                new Claim("DistinguishedName", userInfo?.DistinguishedName),
                new Claim("UserPrincipalName", userInfo?.UserPrincipalName),
                new Claim("UserLogin", userInfo?.UserLogin),
                new Claim("FirstName", userInfo?.FirstName),
                new Claim("LastName", userInfo?.LastName),
                new Claim("DisplayName", userInfo?.DisplayName),
                new Claim("Company", userInfo?.Company),
                new Claim("Department", userInfo?.Department),
                new Claim("Title", userInfo?.Title),
                new Claim("StreetAddress", userInfo?.StreetAddress),
                new Claim("PostalCode", userInfo?.PostalCode),
                new Claim("City", userInfo?.City),
                new Claim("Country", userInfo?.Country.ToJson()),
                new Claim("Email", userInfo?.Email),
                new Claim("MobileNumber", userInfo?.MobileNumber),
                new Claim("TelephoneNumber", userInfo?.TelephoneNumber)
            };

            Parallel.ForEach(GlobalConfig.ApplicationRoles, GlobalConfig.ParallelOptions, role =>
            {
                claims.Add(new Claim($"Permissions.{role.Name}", _adService.IsMemberOfGroup(domain, role, userInfo?.UserLogin, IdentityType.SamAccountName).ToString()));
            });

            ClaimsPrincipal principal = new(new ClaimsIdentity(claims.AsEnumerable(), CookieAuthenticationDefaults.AuthenticationScheme));
            AuthenticationProperties props = new();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

            return RedirectToLastPage();
        }
    }
}

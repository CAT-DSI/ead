using EAD.Data.Enums;
using EAD.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Linq;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="HttpRequest" />
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Getting browser's language
        /// </summary>
        /// <param name="request"><see cref="HttpRequest"/> object</param>
        public static string GetBrowserLanguage(this HttpRequest request)
        {
            if (request != null)
            {
                string lang = request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
                if (string.IsNullOrEmpty(lang))
                {
                    lang = "en";
                }

                return lang.Contains('-') ? lang : lang.Equals("en") ? "en-US" : $"{lang}-{lang.ToUpper()}";
            }
            else
            {
                return "en-US";
            }
        }

        /// <summary>
        /// Getting value of cookie
        /// </summary>
        /// <param name="request"><see cref="HttpRequest"/> object</param>
        /// <param name="cookieId">Cookie's ID</param>
        public static string GetCookie(this HttpRequest request, string cookieId)
        {
            return request != null && !string.IsNullOrEmpty(cookieId) ? CookieHelper.GetValue(request, cookieId) : null;
        }

        /// <summary>
        /// Getting <see cref="Language"/> for <paramref name="request"/>
        /// </summary>
        /// <param name="request"><see cref="HttpRequest"/> object</param>
        public static Language GetLanguage(this HttpRequest request)
        {
            if (request != null)
            {
                string language = request.GetCookie(CookieRequestCultureProvider.DefaultCookieName);
                if (string.IsNullOrEmpty(language))
                {
                    language = request.GetBrowserLanguage();
                }

                return language.ToEnum(Language.English);
            }
            else
            {
                return Language.English;
            }
        }

        /// <summary>
        /// Getting 'Referer' header for <paramref name="request"/>
        /// </summary>
        /// <param name="request"><see cref="HttpRequest"/> object</param>
        public static string GetReferer(this HttpRequest request)
        {
            return request.Headers["Referer"];
        }
    }
}

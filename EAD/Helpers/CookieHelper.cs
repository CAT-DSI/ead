using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Helpers
{
    /// <summary>
    /// Cookie helper methods
    /// </summary>
    public static class CookieHelper
    {
        /// <summary>
        /// Ignoring cookies list
        /// </summary>
        private static readonly string[] _ignoreCookies = new string[] { "Domain", "UserName", CookieRequestCultureProvider.DefaultCookieName };

        /// <summary>
        /// Clearing cookies
        /// </summary>
        /// <param name="httpRequest"><see cref="HttpRequest"/> object</param>
        /// <param name="httpResponse"><see cref="HttpResponse"/> object</param>
        public static void Clear(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            if (httpRequest != null && httpResponse != null)
            {
                Parallel.ForEach(httpRequest.Cookies.Keys.Where(x => !_ignoreCookies.Any(c => c == x)), GlobalConfig.ParallelOptions, key =>
                {
                    httpResponse.Cookies.Delete(key);
                });
            }
        }

        /// <summary>
        /// Getting cookie value
        /// </summary>
        /// <param name="httpRequest"><see cref="HttpRequest"/> object</param>
        /// <param name="key">Cookie key (ID)</param>
        public static string GetValue(HttpRequest httpRequest, string key)
        {
            return httpRequest != null && !string.IsNullOrEmpty(key) ? httpRequest.Cookies[key] : null;
        }

        /// <summary>
        /// Setting cookie value
        /// </summary>
        /// <param name="httpResponse"><see cref="HttpResponse"/> object</param>
        /// <param name="key">Cookie key (ID)</param>
        /// <param name="value">Cookie value</param>
        /// <param name="isNeverExpires">Specifies if cookie never expires</param>
        public static void SetValue(HttpResponse httpResponse, string key, string value, bool isNeverExpires = false)
        {
            if (httpResponse != null && !string.IsNullOrEmpty(key))
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "";
                }

                if (isNeverExpires)
                {
                    httpResponse.Cookies.Append(key, value, new CookieOptions()
                    {
                        Expires = DateTimeOffset.MaxValue
                    });
                }
                else
                {
                    httpResponse.Cookies.Append(key, value);
                }
            }
        }
    }
}

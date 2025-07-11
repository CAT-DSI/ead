using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="HttpResponse" />
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Setting response language
        /// </summary>
        /// <param name="response"><see cref="HttpResponse"/> object</param>
        /// <param name="culture">New language</param>
        public static void SetLanguage(this HttpResponse response, string culture = "en-US")
        {
            response?.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}

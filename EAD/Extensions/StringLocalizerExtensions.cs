using Microsoft.Extensions.Localization;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="StringLocalizer{TResourceSource}"/>
    /// </summary>
    public static class StringLocalizerExtensions
    {
        /// <summary>
        /// Getting localized value for  <paramref name="key"/>
        /// </summary>
        /// <param name="stringLocalizer"><see cref="IStringLocalizer"/> object</param>
        /// <param name="key">Localization key</param>
        /// <param name="isUnicode">Determines whether the value is returned as unicode</param>
        public static string GetValue<T>(this IStringLocalizer<T> stringLocalizer, string key, bool isUnicode = false)
        {
            return isUnicode ? stringLocalizer?[key].Value.ToUnicode() : stringLocalizer?[key].Value;
        }
    }
}

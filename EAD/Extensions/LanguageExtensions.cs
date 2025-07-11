using EAD.Attributes;
using EAD.Data.Enums;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="Language" />
    /// </summary>
    public static class LanguageExtensions
    {
        /// <summary>
        /// Getting value of <see cref="LanguageIdAttribute"/> for <paramref name="language"/>
        /// </summary>
        /// <param name="language"><see cref="Language"/> value</param>
        public static string ToLanguageId(this Language language)
        {
            string languageId = language.GetAttribute<LanguageIdAttribute>()?.Id;

            return !string.IsNullOrEmpty(languageId) ? languageId : "en-US";
        }
    }
}

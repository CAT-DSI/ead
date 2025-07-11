using EAD.Attributes;
using EAD.Data.Enums;
using System;
using System.Linq;

namespace EAD.Helpers
{
    /// <summary>
    /// <see cref="Enum"/> helper methods
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Converting <paramref name="value"/> into <see cref="Country"/>
        /// </summary>
        /// <param name="value">String value</param>
        public static Country GetCountry(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Country.Unknown;
            }

            if (!int.TryParse(value, out int countryCode))
            {
                (Country, CountryCodeAttribute) country = GlobalConfig.Countries.Where(x => x.Item2.Alfa2 == value || x.Item2.Alfa3 == value).DefaultIfEmpty((Country.Unknown, null)).FirstOrDefault();
                return country != (Country.Unknown, null) ? country.Item1 : Country.Unknown;
            }

            return (Country)countryCode;
        }
    }
}

using EAD.Data.Enums;
using EAD.Data.Structures;
using EAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="string" />
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Values that specify true
        /// </summary>
        private static readonly IEnumerable<string> _trueAcceptValues = new List<string>()
        {
            "true", "tak", "yes", "1"
        };

        /// <summary>
        /// Unicode mapping list
        /// </summary>
        private static readonly IEnumerable<UnicodeValue> _unicodeValues = new List<UnicodeValue>()
        {
            new UnicodeValue("ą", "\\u0105"), new UnicodeValue("Ą", "\\u0104"),
            new UnicodeValue("ć", "\\u0107"), new UnicodeValue("Ć", "\\u0106"),
            new UnicodeValue("ę", "\\u0119"), new UnicodeValue("Ę", "\\u0118"),
            new UnicodeValue("ł", "\\u0142"), new UnicodeValue("Ł", "\\u0141"),
            new UnicodeValue("ń", "\\u0144"), new UnicodeValue("Ń", "\\u0143"),
            new UnicodeValue("ó", "\\u00f3"), new UnicodeValue("Ó", "\\u00d3"),
            new UnicodeValue("ś", "\\u015B"), new UnicodeValue("Ś", "\\u015A"),
            new UnicodeValue("ź", "\\u017A"), new UnicodeValue("Ź", "\\u0179"),
            new UnicodeValue("ż", "\\u017C"), new UnicodeValue("Ż", "\\u017B"),
            new UnicodeValue("&#xA;", "\\u000A"), new UnicodeValue("'", "\\u0027")
        };

        /// <summary>
        /// Converting <paramref name="filePath"/> into <see cref="BarcodeFileViewModel"/>
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="directoryType">Directory type</param>
        public static BarcodeFileViewModel ToBarcodeFile(this string filePath, DirectoryType directoryType)
        {
            BarcodeFileViewModel viewModel = null;
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string[] values = fileName.Split('_');

            if (DateTime.TryParseExact(values[1], "yyyyMMddHHmmss", new CultureInfo("pl-PL"), DateTimeStyles.None, out DateTime dateTime))
            {
                viewModel = new BarcodeFileViewModel
                {
                    Barcode = values.Length == 3 ? values[2] : "No_Barcode",
                    Date = dateTime,
                    Name = fileName,
                    OrgUnit = values[0],
                    Path = filePath,
                    RemotePath = $"/files/{directoryType}/{Path.GetFileName(filePath)}"
                };
            }

            return viewModel;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into <see cref="bool"/>
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="defaultValue">Default value if <paramref name="value"/> is null or empty</param>
        public static bool ToBoolean(this string value, bool defaultValue = false)
        {
            return !string.IsNullOrEmpty(value) ? _trueAcceptValues.Any(x => string.Equals(value, x, StringComparison.OrdinalIgnoreCase)) : defaultValue;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into <see cref="DateTime"/>
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        public static DateTime ToDateTime(this string value, DateTime defaultValue = new DateTime())
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into <see cref="double"/>
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        public static double ToDouble(this string value, double defaultValue = 0)
        {
            try
            {
                return Convert.ToDouble(value?.Replace(",", "."));
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into <see cref="Enum"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        public static T ToEnum<T>(this string value, T defaultValue = default)
        {
            try
            {
                if (typeof(T) == typeof(Language))
                {
                    value = value.Contains("pl-PL") || value.Contains("c=pl") ? "Polish" : "English";
                }

                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into <see cref="float"/>
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        public static float ToFloat(this string value, float defaultValue = 0)
        {
            try
            {
                return float.Parse(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into <see cref="int"/>
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        public static int ToInteger(this string value, int defaultValue = 0)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into nullable <see cref="bool"/>
        /// </summary>
        /// <param name="value">String value</param>
        public static bool? ToNullBoolean(this string value)
        {
            return !string.IsNullOrEmpty(value) && _trueAcceptValues.Any(x => string.Equals(value, x, StringComparison.OrdinalIgnoreCase)) ? (bool?)true : null;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into nullable <see cref="DateTime"/>
        /// </summary>
        /// <param name="value">String value</param>
        public static DateTime? ToNullDateTime(this string value)
        {
            return !string.IsNullOrEmpty(value) && DateTime.TryParse(value?.Replace(",", "."), out DateTime result) ? (DateTime?)result : null;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into nullable <see cref="double"/>
        /// </summary>
        /// <param name="value">String value</param>
        public static double? ToNullDouble(this string value)
        {
            return !string.IsNullOrEmpty(value) && double.TryParse(value?.Replace(",", "."), out double result) ? (double?)result : null;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into nullable <see cref="float"/>
        /// </summary>
        /// <param name="value">String value</param>
        public static float? ToNullFloat(this string value)
        {
            return !string.IsNullOrEmpty(value) && float.TryParse(value, out float result) ? (float?)result : null;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into nullable <see cref="int"/>
        /// </summary>
        /// <param name="value">String value</param>
        public static int? ToNullInteger(this string value)
        {
            return !string.IsNullOrEmpty(value) && int.TryParse(value, out int result) ? (int?)result : null;
        }

        /// <summary>
        /// Converting string <paramref name="value"/> into unicode representation
        /// </summary>
        /// <param name="value">String value</param>
        public static string ToUnicode(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                foreach (UnicodeValue unicodeValue in _unicodeValues)
                {
                    value = value.Replace(unicodeValue.Value, unicodeValue.Unicode);
                }

                return value;
            }
            else
            {
                return value;
            }
        }
    }
}

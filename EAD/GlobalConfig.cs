using EAD.Attributes;
using EAD.Data.Enums;
using EAD.Models;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace EAD
{
    public static class GlobalConfig
    {
        public const string DateFormat = "yyyy-MM-dd";

        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public const int MaxRetryCounter = 10;

        public const string TimeFormat = "HH:mm:ss";

        public static readonly RequestCulture DefaultRequestCulture = new("en-US");

        public static readonly ParallelOptions ParallelOptions = new() { MaxDegreeOfParallelism = 10 };

        public static readonly IList<CultureInfo> SupportedCultures = new List<CultureInfo>() { new("pl-PL"), new("en-US") };

        public static List<ApplicationRole> ApplicationRoles { get; set; } = new List<ApplicationRole>();

        public static IEnumerable<(Country, CountryCodeAttribute)> Countries { get; internal set; } = new List<(Country, CountryCodeAttribute)>();

        public static List<Domain> Domains { get; set; } = new List<Domain>();

        public static string RootDirectory { get; set; }

        public static string GetDirectory(DirectoryType directoryType)
        {
            return $"{RootDirectory}\\files\\{directoryType}";
        }
    }
}

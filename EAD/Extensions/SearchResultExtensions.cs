using EAD.Data.Enums;
using EAD.Helpers;
using System;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="SearchResult" />
    /// </summary>
    public static class SearchResultExtensions
    {
        /// <summary>
        /// Getting <see cref="bool"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static bool GetBoolean(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToBoolean();
        }

        /// <summary>
        /// Getting <see cref="byte"/>[] value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static byte[] GetBytes(this SearchResult searchResult, string propertyName)
        {
            return searchResult != null && !string.IsNullOrEmpty(propertyName) ? !searchResult.Properties.Contains(propertyName) ? new byte[0] : (byte[])searchResult.Properties[propertyName][0] : new byte[0];
        }

        /// <summary>
        /// Getting <see cref="DateTime"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static DateTime GetDateTime(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToDateTime();
        }

        /// <summary>
        /// Getting <see cref="double"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static double GetDouble(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToDouble();
        }

        /// <summary>
        /// Getting <see cref="float"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static float GetFloat(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToFloat();
        }

        /// <summary>
        /// Getting <see cref="int"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static int GetInteger(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToInteger();
        }

        /// <summary>
        /// Getting nullable <see cref="bool"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static bool? GetNullBoolean(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToNullBoolean();
        }

        /// <summary>
        /// Getting nullable <see cref="DateTime"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static DateTime? GetNullDateTime(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToNullDateTime();
        }

        /// <summary>
        /// Getting nullable <see cref="double"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static double? GetNullDouble(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToNullDouble();
        }

        /// <summary>
        /// Getting nullable <see cref="float"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static float? GetNullFloat(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToNullFloat();
        }

        /// <summary>
        /// Getting nullable <see cref="int"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static int? GetNullInteger(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName).ToNullInteger();
        }

        /// <summary>
        /// Getting <see cref="string"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static string GetProperty(this SearchResult searchResult, string propertyName)
        {
            return searchResult != null && !string.IsNullOrEmpty(propertyName) && searchResult.Properties.Contains(propertyName) ? searchResult.Properties[propertyName][0].ToString() : string.Empty;
        }

        /// <summary>
        /// Getting <see cref="string"/> value of property <paramref name="propertyName"/> from <paramref name="searchResult"/>
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static string GetString(this SearchResult searchResult, string propertyName)
        {
            return searchResult.GetProperty(propertyName);
        }

        /// <summary>
        /// Converting <paramref name="searchResult"/> into <typeparamref name="T"/> object
        /// </summary>
        /// <param name="searchResult"><see cref="SearchResult"/> object</param>
        public static T ToObject<T>(this SearchResult searchResult)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            Parallel.ForEach(PropertyExtensions.GetPropertyNames<T>(), GlobalConfig.ParallelOptions, settings =>
            {
                if (string.Equals(settings.AttributeName, ActiveDirectoryHelper.ObjectSid, StringComparison.OrdinalIgnoreCase))
                {
                    obj.SetProperty(settings.PropertyName, searchResult.GetBytes(ActiveDirectoryHelper.ObjectSid).ToSid());
                }
                else
                {
                    if (settings.PropertyType == typeof(bool))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetBoolean(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(DateTime))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetDateTime(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(double))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetDouble(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(float))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetFloat(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(int))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetInteger(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(bool?))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetNullBoolean(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(DateTime?))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetNullDateTime(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(double?))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetNullDouble(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(float?))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetNullFloat(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(int?))
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetNullInteger(settings.AttributeName));
                    }
                    else if (settings.PropertyType == typeof(Country))
                    {
                        Country country = EnumHelper.GetCountry(searchResult.GetString(settings.AttributeName));
                        if (country == Country.Unknown)
                        {
                            string c = searchResult.GetString("c");
                            if (!string.IsNullOrEmpty(c))
                            {
                                obj.SetProperty(settings.PropertyName, EnumHelper.GetCountry(c));
                            }
                            else
                            {
                                obj.SetProperty(settings.PropertyName, EnumHelper.GetCountry("co"));
                            }
                        }
                        else
                        {
                            obj.SetProperty(settings.PropertyName, country);
                        }
                    }
                    else
                    {
                        obj.SetProperty(settings.PropertyName, searchResult.GetString(settings.AttributeName));
                    }
                }
            });

            return obj;
        }
    }
}

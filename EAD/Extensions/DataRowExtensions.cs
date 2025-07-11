using EAD.Data.Enums;
using EAD.Data.Structures;
using EAD.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="DataRow" />
    /// </summary>
    public static class DataRowExtensions
    {
        /// <summary>
        /// Getting <see cref="bool"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static bool GetBoolean(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToBoolean();
        }

        /// <summary>
        /// Getting <see cref="DateTime"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static DateTime GetDateTime(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToDateTime();
        }

        /// <summary>
        /// Getting <see cref="double"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static double GetDouble(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToDouble();
        }

        /// <summary>
        /// Getting <see cref="float"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static float GetFloat(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToFloat();
        }

        /// <summary>
        /// Getting <see cref="int"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static int GetInteger(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToInteger();
        }

        /// <summary>
        /// Getting nullable <see cref="bool"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static bool? GetNullBoolean(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToNullBoolean();
        }

        /// <summary>
        /// Getting nullable <see cref="DateTime"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static DateTime? GetNullDateTime(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToNullDateTime();
        }

        /// <summary>
        /// Getting nullable <see cref="double"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static double? GetNullDouble(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToNullDouble();
        }

        /// <summary>
        /// Getting nullable <see cref="float"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static float? GetNullFloat(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToNullFloat();
        }

        /// <summary>
        /// Getting nullable <see cref="int"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static int? GetNullInteger(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames).ToNullInteger();
        }

        /// <summary>
        /// Getting <see cref="string"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static string GetString(this DataRow dataRow, string[] columnNames)
        {
            return dataRow.GetValue(columnNames);
        }

        /// <summary>
        /// Getting <see cref="string"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        public static string GetString(this DataRow dataRow, int columnIndex)
        {
            return dataRow.GetValue(columnIndex);
        }

        /// <summary>
        /// Converting <paramref name="dataRow"/> into <typeparamref name="T"/> object
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNamesSettings">List of <see cref="ColumnNamesSettings"/></param>
        public static T ToObject<T>(this DataRow dataRow, IEnumerable<ColumnNamesSettings> columnNamesSettings)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            Parallel.ForEach(columnNamesSettings, GlobalConfig.ParallelOptions, settings =>
            {
                if (settings.PropertyType == typeof(bool))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetBoolean(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(DateTime))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetDateTime(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(double))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetDouble(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(float))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetFloat(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(int))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetInteger(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(bool?))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetNullBoolean(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(DateTime?))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetNullDateTime(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(double?))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetNullDouble(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(float?))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetNullFloat(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(int?))
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetNullInteger(settings.ColumnNames));
                }
                else if (settings.PropertyType == typeof(Country))
                {
                    obj.SetProperty(settings.PropertyName, EnumHelper.GetCountry(dataRow.GetString(settings.ColumnNames)));
                }
                else
                {
                    obj.SetProperty(settings.PropertyName, dataRow.GetString(settings.ColumnNames));
                }
            });

            return obj;
        }

        /// <summary>
        /// Getting <see cref="string"/> value for columns <paramref name="columnNames"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        private static string GetValue(this DataRow dataRow, string[] columnNames)
        {
            string value = null;
            foreach (string columnName in columnNames)
            {
                try
                {
                    if (dataRow.Table.Columns.Contains(columnName))
                    {
                        value = Convert.ToString(dataRow[columnName]);
                    }
                }
                catch
                {
                    //ingore
                }

                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Getting <see cref="string"/> value for index <paramref name="columnIndex"/> of <paramref name="dataRow"/>
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> object</param>
        /// <param name="columnNames">Array with column names</param>
        private static string GetValue(this DataRow dataRow, int columnIndex)
        {
            try
            {
                return Convert.ToString(dataRow[columnIndex]);
            }
            catch
            {
                return null;
            }
        }
    }
}

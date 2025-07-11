using EAD.Attributes;
using EAD.Data.Structures;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="Type"/>
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Getting configurations or <see cref="ColumnNamesAttribute"/> for <see cref="Type"/> properties
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<ColumnNamesSettings> GetColumnNames(this Type type)
        {
            List<ColumnNamesSettings> columnNames = new List<ColumnNamesSettings>();

            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                ColumnNamesAttribute attribute = type.GetAttribute<ColumnNamesAttribute>(prop.Name);
                if (attribute != null)
                {
                    columnNames.Add(new ColumnNamesSettings(prop.PropertyType, prop.Name, attribute.Names));
                }
            }

            return columnNames;
        }
    }
}

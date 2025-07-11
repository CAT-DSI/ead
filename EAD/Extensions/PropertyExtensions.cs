using EAD.Attributes;
using EAD.Data.Structures;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="object" />
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// Getting property names setting of <typeparamref name="T"/>
        /// </summary>
        public static IEnumerable<PropertyNameSettings> GetPropertyNames<T>()
        {
            List<PropertyNameSettings> propertyNames = new();

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                PropertyNameAttribute attribute = typeof(T).GetAttribute<PropertyNameAttribute>(prop.Name);
                if (attribute != null)
                {
                    propertyNames.Add(new PropertyNameSettings(prop.PropertyType, prop.Name, attribute.Name));
                }
            }

            return propertyNames.AsEnumerable();
        }

        /// <summary>
        /// Setting object's property value
        /// </summary>
        /// <param name="obj"><see cref="object"/></param>
        /// <param name="name">Property name</param>
        /// <param name="value">Property value</param>
        public static bool SetProperty(this object obj, string name, object value)
        {
            PropertyInfo prop = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (null == prop || !prop.CanWrite)
            {
                return false;
            }
            else
            {
                prop.SetValue(obj, value, null);
                return true;
            }
        }
    }
}

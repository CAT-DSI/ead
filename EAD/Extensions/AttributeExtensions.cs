using System;
using System.Linq;
using System.Reflection;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="Attribute" />
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Getting attribute of type <typeparamref name="TAttribute"/> for <see cref="Enum"/> <paramref name="value"/>
        /// </summary>
        /// <param name="value"><see cref="Enum"/> value</param>
        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            return !string.IsNullOrEmpty(name) ? type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().FirstOrDefault() : null;
        }

        /// <summary>
        /// Getting <typeparamref name="TAttribute"/> of <see cref="Type"/> <paramref name="type"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/> object</param>
        /// <param name="fieldName">Field name</param>
        public static TAttribute GetAttribute<TAttribute>(this Type type, string fieldName) where TAttribute : Attribute
        {
            return type?.GetProperty(fieldName)?.GetCustomAttribute<TAttribute>();
        }
    }
}

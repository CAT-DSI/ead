using System;

namespace EAD.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ColumnNamesAttribute : Attribute
    {
        public ColumnNamesAttribute(string[] names)
        {
            Names = names;
        }

        public string[] Names { get; }
    }
}
using System;

namespace EAD.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class CountryCodeAttribute : Attribute
    {
        public CountryCodeAttribute()
        {
        }

        public CountryCodeAttribute(string alfa2, string alfa3)
        {
            Alfa2 = alfa2;
            Alfa3 = alfa3;
        }

        public string Alfa2 { get; }

        public string Alfa3 { get; }
    }
}
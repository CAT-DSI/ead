using System;

namespace EAD.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class LanguageIdAttribute : Attribute
    {
        public LanguageIdAttribute(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
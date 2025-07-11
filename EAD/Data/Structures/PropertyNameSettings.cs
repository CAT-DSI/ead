using System;

namespace EAD.Data.Structures
{
    public struct PropertyNameSettings
    {
        public PropertyNameSettings(Type type, string propertyName, string attributeName)
        {
            AttributeName = attributeName;
            PropertyName = propertyName;
            PropertyType = type;
        }

        public string AttributeName { get; set; }

        public string PropertyName { get; }

        public Type PropertyType { get; }
    }
}
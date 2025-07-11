using System;

namespace EAD.Data.Structures
{
    public struct ColumnNamesSettings
    {
        public ColumnNamesSettings(Type type, string propertyName, string[] columnNames)
        {
            ColumnNames = columnNames;
            PropertyName = propertyName;
            PropertyType = type;
        }

        public string[] ColumnNames { get; }

        public string PropertyName { get; }

        public Type PropertyType { get; }
    }
}
using ExcelDataReader;
using System.Data;
using System.IO;

namespace EAD.Helpers
{
    /// <summary>
    /// Excel read helper
    /// </summary>
    public static class ExcelReadHelper
    {
        /// <summary>
        /// Getting <see cref="DataTable"/> for file <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="isFirstRowHeader">Specifies if first row is headers row</param>
        public static DataTable GetDataTable(string filePath, bool isFirstRowHeader = true)
        {
            if (File.Exists(filePath))
            {
                using FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                using IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                ExcelDataSetConfiguration conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = isFirstRowHeader
                    }
                };

                DataSet dataSet = reader.AsDataSet(conf);
                return dataSet.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}

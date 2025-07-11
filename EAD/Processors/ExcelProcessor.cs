using EAD.Data.Enums;
using EAD.ViewModels;
using System.Collections.Generic;
using System.Data;

namespace EAD.Processors
{
    /// <summary>
    /// Excel processing methods
    /// </summary>
    public static class ExcelProcessor
    {
        /// <summary>
        /// Creating <see cref="DataTable"/> from <paramref name="viewModels"/>
        /// </summary>
        /// <param name="viewModels">List of OCR configurations</param>
        /// <param name="language">Column name language</param>
        public static DataTable CreateTable(IEnumerable<OcrConfigurationViewModel> viewModels, Language language)
        {
            DataTable dataTable = CreateTable(language);
            foreach (OcrConfigurationViewModel viewModel in viewModels)
            {
                dataTable.Rows.Add(viewModel.Name, viewModel.BarcodeLength, viewModel.BarcodePrefix, viewModel.BarcodeSuffix, viewModel.DirectoryPath, viewModel.Host, viewModel.Port, viewModel.IsSFTP, viewModel.Username, viewModel.Password, viewModel.FileName, viewModel.Directory);
            }

            return dataTable;
        }

        /// <summary>
        /// Getting output file name
        /// </summary>
        /// <param name="language">File name language</param>
        public static string GetOutputFileName(Language language)
        {
            return language == Language.Polish ? "Lista konfiguracji OCR.xlsx" : "OCR Configuration List.xlsx";
        }

        /// <summary>
        /// Creating <see cref="DataTable"/>
        /// </summary>
        /// <param name="language">Table column name language</param>
        private static DataTable CreateTable(Language language)
        {
            if (language == Language.Polish)
            {
                DataTable dataTable = new("Lista konfiguracji OCR");
                dataTable.Columns.Add(new DataColumn("Nazwa"));
                dataTable.Columns.Add(new DataColumn("Długość"));
                dataTable.Columns.Add(new DataColumn("Prefiks"));
                dataTable.Columns.Add(new DataColumn("Sufiks"));
                dataTable.Columns.Add(new DataColumn("Folder"));
                dataTable.Columns.Add(new DataColumn("Host"));
                dataTable.Columns.Add(new DataColumn("Port"));
                dataTable.Columns.Add(new DataColumn("SFTP"));
                dataTable.Columns.Add(new DataColumn("Login"));
                dataTable.Columns.Add(new DataColumn("Hasło"));
                dataTable.Columns.Add(new DataColumn("Nazwa pliku"));
                dataTable.Columns.Add(new DataColumn("Folder startowy"));

                return dataTable;
            }
            else
            {
                DataTable dataTable = new("OCR Configuration List");
                dataTable.Columns.Add(new DataColumn("Name"));
                dataTable.Columns.Add(new DataColumn("Length"));
                dataTable.Columns.Add(new DataColumn("Prefix"));
                dataTable.Columns.Add(new DataColumn("Suffix"));
                dataTable.Columns.Add(new DataColumn("Directory path"));
                dataTable.Columns.Add(new DataColumn("Host"));
                dataTable.Columns.Add(new DataColumn("Port"));
                dataTable.Columns.Add(new DataColumn("Is SFTP"));
                dataTable.Columns.Add(new DataColumn("Username"));
                dataTable.Columns.Add(new DataColumn("Password"));
                dataTable.Columns.Add(new DataColumn("File name"));
                dataTable.Columns.Add(new DataColumn("Start directory"));

                return dataTable;
            }
        }
    }
}

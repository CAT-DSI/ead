using EAD.Extensions;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EAD.Processors
{
    /// <summary>
    /// PDF processing methods
    /// </summary>
    public static class PdfProcessor
    {
        /// <summary>
        /// Mering <paramref name="filePaths"/> into one file <paramref name="outputFilePath"/>
        /// </summary>
        /// <param name="filePaths">List of input files</param>
        /// <param name="outputFilePath">Output file path</param>
        public static async Task MergeFiles(List<string> filePaths, string outputFilePath)
        {
            if (filePaths.IsValid() && !string.IsNullOrEmpty(outputFilePath))
            {
                using PdfDocument output = new();
                foreach (string filePath in filePaths)
                {
                    if (File.Exists(filePath))
                    {
                        using PdfDocument document = await GetPdfReader(filePath);
                        CopyPages(document, output);
                    }
                }

                output.Save(outputFilePath);
            }
        }

        /// <summary>
        /// Copy pages from <paramref name="source"/> file into <paramref name="destination"/>
        /// </summary>
        /// <param name="source">Source PDF document</param>
        /// <param name="destination">Destination PDF document</param>
        private static void CopyPages(PdfDocument source, PdfDocument destination)
        {
            if (source != null && destination != null)
            {
                for (int i = 0; i < source.PageCount; i++)
                {
                    destination.AddPage(source.Pages[i]);
                }
            }
        }

        /// <summary>
        /// Reading PDF document from <paramref name="filePath"/> file
        /// </summary>
        /// <param name="filePath">File path</param>
        private static async Task<PdfDocument> GetPdfReader(string filePath)
        {
            try
            {
                return PdfReader.Open(filePath, PdfDocumentOpenMode.Import);
            }
            catch (IOException)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                return await GetPdfReader(filePath);
            }
        }
    }
}

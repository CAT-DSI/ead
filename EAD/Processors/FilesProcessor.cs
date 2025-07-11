using EAD.Data.Enums;
using EAD.Data.Structures;
using EAD.Extensions;
using EAD.ViewModels;
using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EAD.Processors
{
    /// <summary>
    /// Files processing methods
    /// </summary>
    public static class FilesProcessor
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Deleting file from <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath">File path</param>
        public static bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

                return !File.Exists(filePath);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Getting list of <see cref="BarcodeFileViewModel"/> from <paramref name="directoryType"/> directory
        /// </summary>
        /// <param name="directoryType">Directory type</param>
        public static IEnumerable<BarcodeFileViewModel> GetBarcodeFileViewModels(DirectoryType directoryType)
        {
            ConcurrentBag<BarcodeFileViewModel> viewModels = new();

            try
            {
                Parallel.ForEach(Directory.GetFiles(GlobalConfig.GetDirectory(directoryType)), GlobalConfig.ParallelOptions, filePath =>
                {
                    if (filePath.Contains(@"\\"))
                    {
                        filePath = filePath.Replace(@"\\", @"\");
                    }

                    viewModels.AddObject(filePath.ToBarcodeFile(directoryType));
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return viewModels.AsEnumerable();
        }

        /// <summary>
        /// Saving <paramref name="file"/> into directory <paramref name="directoryPath"/>
        /// </summary>
        /// <param name="file">File to save</param>
        /// <param name="directoryPath">Directory path</param>
        /// <param name="isUniqueFileName">Specifies if file name should be uniqe</param>
        public static async Task<RemoteFile> SaveFile(IFormFile file, string directoryPath, bool isUniqueFileName = false)
        {
            if (file != null && !string.IsNullOrEmpty(directoryPath))
            {
                string extension = Path.GetExtension($"{directoryPath}\\{file.FileName}");
                string filePath = isUniqueFileName ? $"{directoryPath}\\{Guid.NewGuid()}{extension}" : $"{directoryPath}\\{file.FileName}";

                try
                {
                    Directory.CreateDirectory(directoryPath);
                    using FileStream fileStream = new(filePath, FileMode.Create);
                    await file.CopyToAsync(fileStream);

                    return new RemoteFile(filePath, file.FileName);
                }
                catch
                {
                    return new RemoteFile();
                }
            }
            else
            {
                return new RemoteFile();
            }
        }
    }
}

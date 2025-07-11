using EAD.Models;
using EAD.ViewModels;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="FtpResult" />
    /// </summary>
    public static class FtpResultExtensions
    {
        /// <summary>
        /// Converting <paramref name="result"/> into <see cref="FtpResultViewModel"/>
        /// </summary>
        /// <param name="result"><see cref="FtpResult"/> object</param>
        public static FtpResultViewModel ToViewModel(this FtpResult result)
        {
            string filePath = result.FilePath;

            return new FtpResultViewModel()
            {
                Barcode = result.Barcode,
                Date = result.Date,
                Directory = result.FtpConfiguration?.Directory,
                FileName = result.FtpConfiguration?.FileName,
                FilePath = result.FilePath,
                FtpConfigurationId = result.FtpConfigurationId,
                Host = result.FtpConfiguration?.Host,
                IsSFTP = result.FtpConfiguration?.IsSFTP,
                Password = result.FtpConfiguration?.Password,
                Port = result.FtpConfiguration?.Port,
                Status = result.Status,
                Username = result.FtpConfiguration?.Username,
                RemotePath = !string.IsNullOrEmpty(filePath) ? $"{filePath[filePath.IndexOf("\\files")..]}".Replace("\\", "/") : null
            };
        }
    }
}

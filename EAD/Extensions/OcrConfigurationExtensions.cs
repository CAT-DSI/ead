using EAD.Models;
using EAD.ViewModels;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="OcrConfiguration" />
    /// </summary>
    public static class OcrConfigurationExtensions
    {
        /// <summary>
        /// Converting <paramref name="configuration"/> into <see cref="OcrConfigurationViewModel"/>
        /// </summary>
        /// <param name="configuration"><see cref="OcrConfiguration"/> object</param>
        public static OcrConfigurationViewModel ToViewModel(this OcrConfiguration configuration)
        {
            return new OcrConfigurationViewModel()
            {
                BarcodeLength = configuration.BarcodeLength,
                BarcodeSuffix = configuration.BarcodeSuffix,
                BarcodePrefix = configuration.BarcodePrefix,
                CreatedById = configuration.CreatedById,
                CreatedDate = configuration.CreatedDate,
                DirectoryPath = configuration.DirectoryPath,
                Id = configuration.Id,
                Name = configuration.Name,
                UpdatedById = configuration.UpdatedById,
                UpdatedDate = configuration.UpdatedDate,
                Directory = configuration.FtpConfiguration?.Directory,
                FileName = configuration.FtpConfiguration?.FileName,
                FtpConfigurationId = configuration.FtpConfiguration != null ? configuration.FtpConfiguration.Id : 0,
                Host = configuration.FtpConfiguration?.Host,
                IsSFTP = configuration.FtpConfiguration?.IsSFTP,
                Password = configuration.FtpConfiguration?.Password,
                Port = configuration.FtpConfiguration != null ? configuration.FtpConfiguration.Port : 0,
                Username = configuration.FtpConfiguration?.Username
            };
        }
    }
}

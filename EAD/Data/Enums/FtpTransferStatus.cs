using System.ComponentModel.DataAnnotations;

namespace EAD.Data.Enums
{
    public enum FtpTransferStatus
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "Success")]
        Success = 1,

        [Display(Name = "Error")]
        Error = 2,

        [Display(Name = "FileNotFound")]
        FileNotFound = 3,

        [Display(Name = "NoBarcode")]
        NoBarcode = 4
    }
}
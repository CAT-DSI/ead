using EAD.Data.Enums;
using EAD.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EAD.Models
{
    public class FtpResult : IValidable
    {
        public string Barcode { get; set; }

        public DateTime Date { get; set; }

        [Key]
        public string FilePath { get; set; }

        public FtpConfiguration FtpConfiguration { get; set; }

        public int FtpConfigurationId { get; set; }

        public FtpTransferStatus Status { get; set; }

        public bool IsValid()
        {
            return File.Exists(FilePath)
                && FtpConfigurationId > 0
                && !string.IsNullOrEmpty(Barcode);
        }
    }
}
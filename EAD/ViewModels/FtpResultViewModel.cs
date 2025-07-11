using EAD.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EAD.ViewModels
{
    public class FtpResultViewModel
    {
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Directory")]
        [MaxLength(256)]
        public string Directory { get; set; }

        [Display(Name = "FileName")]
        [MaxLength(128)]
        public string FileName { get; set; }

        [Key]
        [Display(Name = "FilePath")]
        public string FilePath { get; set; }

        public int FtpConfigurationId { get; set; }

        [Required]
        [Display(Name = "Host")]
        [MaxLength(64)]
        public string Host { get; set; }

        [Required]
        [Display(Name = "IsSFTP")]
        public bool? IsSFTP { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Port")]
        public int? Port { get; set; }

        [Display(Name = "RemotePath")]
        public string RemotePath { get; set; }

        [Display(Name = "Status")]
        public FtpTransferStatus Status { get; set; }

        [Required]
        [Display(Name = "Username")]
        [MaxLength(64)]
        public string Username { get; set; }
    }
}
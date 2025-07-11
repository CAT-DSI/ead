using EAD.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace EAD.Models
{
    public class OcrConfiguration : IValidable
    {
        [Display(Name = "BarcodeLength")]
        public int BarcodeLength { get; set; }

        [Display(Name = "BarcodePrefix")]
        [MaxLength(64)]
        public string BarcodePrefix { get; set; }

        [Display(Name = "BarcodeSuffix")]
        [MaxLength(64)]
        public string BarcodeSuffix { get; set; }

        [Required]
        [Display(Name = "CreatedBy")]
        public string CreatedById { get; set; }

        [Required]
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "DirectoryPath")]
        [MaxLength(256)]
        public string DirectoryPath { get; set; }

        [Display(Name = "FtpConfiguration")]
        public FtpConfiguration FtpConfiguration { get; set; }

        [Display(Name = "FtpConfiguration")]
        public int? FtpConfigurationId { get; set; }

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "UpdatedBy")]
        public string UpdatedById { get; set; }

        [Display(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        public bool IsValid()
        {
            return BarcodeLength > 0
                && (!string.IsNullOrEmpty(BarcodeSuffix) || !string.IsNullOrEmpty(BarcodePrefix))
                && !string.IsNullOrEmpty(CreatedById)
                && !string.IsNullOrEmpty(DirectoryPath)
                && !string.IsNullOrEmpty(Name);
        }
    }
}
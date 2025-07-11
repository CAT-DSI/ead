using EAD.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EAD.ViewModels
{
    public class OcrConfigurationViewModel
    {
        [Display(Name = "BarcodeLength")]
        [ColumnNames(new string[] { "Length", "Długość" })]
        public int BarcodeLength { get; set; }

        [Display(Name = "BarcodePrefix")]
        [MaxLength(64)]
        [ColumnNames(new string[] { "Prefix", "Prefiks" })]
        public string BarcodePrefix { get; set; } = "";

        [Display(Name = "BarcodeSuffix")]
        [MaxLength(64)]
        [ColumnNames(new string[] { "Suffix", "Sufiks" })]
        public string BarcodeSuffix { get; set; } = "";

        [Display(Name = "CreatedBy")]
        public string CreatedById { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Directory")]
        [MaxLength(256)]
        [ColumnNames(new string[] { "Start directory", "Folder startowy" })]
        public string Directory { get; set; }

        [Display(Name = "DirectoryPath")]
        [MaxLength(256)]
        [ColumnNames(new string[] { "Directory path", "Folder" })]
        public string DirectoryPath { get; set; }

        [Display(Name = "FileName")]
        [MaxLength(128)]
        [ColumnNames(new string[] { "File name", "Nazwa pliku" })]
        public string FileName { get; set; }

        [Display(Name = "Id")]
        public int FtpConfigurationId { get; set; }

        [Display(Name = "Host")]
        [MaxLength(64)]
        [ColumnNames(new string[] { "Host" })]
        public string Host { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "IsSFTP")]
        [ColumnNames(new string[] { "Is SFTP", "SFTP" })]
        public bool? IsSFTP { get; set; }

        [Display(Name = "Name")]
        [MaxLength(24)]
        [ColumnNames(new string[] { "Name", "Nazwa" })]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [MaxLength(64)]
        [ColumnNames(new string[] { "Password", "Hasło" })]
        public string Password { get; set; }

        [Display(Name = "Port")]
        [ColumnNames(new string[] { "Port" })]
        public int? Port { get; set; }

        [Display(Name = "UpdatedBy")]
        public string UpdatedById { get; set; }

        [Display(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Username")]
        [MaxLength(64)]
        [ColumnNames(new string[] { "Username" })]
        public string Username { get; set; }
    }
}
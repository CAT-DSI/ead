using System.ComponentModel.DataAnnotations;

namespace EAD.ViewModels
{
    public class FtpConfigurationViewModel
    {
        public int ConfigurationId { get; set; }

        [Display(Name = "Directory")]
        [MaxLength(256)]
        public string Directory { get; set; }

        [Display(Name = "FileName")]
        [MaxLength(128)]
        public string FileName { get; set; }

        [Required]
        [Display(Name = "Host")]
        [MaxLength(64)]
        public string Host { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

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

        [Required]
        [Display(Name = "Username")]
        [MaxLength(64)]
        public string Username { get; set; }
    }
}
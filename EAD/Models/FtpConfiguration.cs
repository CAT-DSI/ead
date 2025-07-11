using EAD.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EAD.Models
{
    public class FtpConfiguration : IValidable
    {
        [Display(Name = "Directory")]
        [MaxLength(256)]
        public string Directory { get; set; }

        [Required]
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
        public bool IsSFTP { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Port")]
        public int Port { get; set; }

        [Required]
        [Display(Name = "Username")]
        [MaxLength(64)]
        public string Username { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Host)
                && !string.IsNullOrEmpty(Password)
                && !string.IsNullOrEmpty(Username)
                && Port > 0;
        }
    }
}
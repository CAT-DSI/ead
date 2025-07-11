using EAD.Extensions;
using EAD.Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EAD.ViewModels
{
    public class LogInViewModel : IValidable
    {
        public LogInViewModel()
        {
        }

        public LogInViewModel(HttpRequest httpRequest)
        {
            Domain = httpRequest.GetCookie("Domain");
            UserName = httpRequest.GetCookie("UserName");
        }

        [Required]
        [Display(Name = "Domain")]
        public string Domain { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Domain)
                && !string.IsNullOrEmpty(UserName)
                && !string.IsNullOrEmpty(Password);
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace EAD.Data.Enums
{
    public enum LogInResult
    {
        [Display(Name = "Success")]
        Success = 0,

        [Display(Name = "UserNotFound")]
        UserNotFound = 1,

        [Display(Name = "WrongCredentials")]
        WrongCredentials = 2,

        [Display(Name = "Error")]
        Error = 3,
    }
}
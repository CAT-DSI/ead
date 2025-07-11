using EAD.Data.Enums;
using EAD.Models;
using EAD.ViewModels;
using System.DirectoryServices.AccountManagement;

namespace EAD.Interfaces.Services
{
    public interface IActiveDirectoryService
    {
        public UserInfo GetUser(Domain domain, string identityValue, IdentityType identityType);

        public bool IsMemberOfGroup(Domain domain, ApplicationRole role, string identityValue, IdentityType identityType);

        public LogInResult ValidateCredentials(Domain domain, LogInViewModel logIn);
    }
}
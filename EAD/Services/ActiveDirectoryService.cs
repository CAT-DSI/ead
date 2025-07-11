using EAD.Data.Enums;
using EAD.Extensions;
using EAD.Helpers;
using EAD.Interfaces.Services;
using EAD.Models;
using EAD.ViewModels;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace EAD.Services
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        public ActiveDirectoryService()
        {
        }

        /// <summary>
        /// Getting user info from domain
        /// </summary>
        /// <param name="domain">Domain type</param>
        /// <param name="identityValue">Identity value</param>
        /// <param name="identityType">Identity type</param>
        public UserInfo GetUser(Domain domain, string identityValue, IdentityType identityType)
        {
            try
            {
                UserInfo userInfo = null;

                if (ValidationHelper.Validate(domain) && !string.IsNullOrEmpty(identityValue))
                {
                    using DirectoryEntry directoryEntry = new DirectoryEntry(domain.Path);
                    if (directoryEntry != null)
                    {
                        using DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry, GetFiler(identityValue, identityType));
                        userInfo = directorySearcher.FindOne().ToObject<UserInfo>();
                    }
                }

                return userInfo;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Determining if user is member or group
        /// </summary>
        /// <param name="domain">Domain type</param>
        /// <param name="role">Application role</param>
        /// <param name="identityValue">Identity value</param>
        /// <param name="identityType">Identity type</param>
        public bool IsMemberOfGroup(Domain domain, ApplicationRole role, string identityValue, IdentityType identityType)
        {
            try
            {
                bool result = false;

                if (ValidationHelper.Validate(domain) && !string.IsNullOrEmpty(identityValue))
                {
                    using PrincipalContext context = new PrincipalContext(ContextType.Domain, domain.Name);
                    if (context != null)
                    {
                        using UserPrincipal user = UserPrincipal.FindByIdentity(context, identityType, identityValue);
                        using GroupPrincipal group = GroupPrincipal.FindByIdentity(context, role.Group);

                        result = user != null && user.Enabled == true && user.IsMemberOf(group);
                    }
                }

                return result;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validating user credentials
        /// </summary>
        /// <param name="domain">Domain type</param>
        /// <param name="logIn">Login values</param>
        public LogInResult ValidateCredentials(Domain domain, LogInViewModel logIn)
        {
            try
            {
                LogInResult result = LogInResult.Error;

                if (ValidationHelper.Validate(domain) && ValidationHelper.Validate(logIn))
                {
                    IdentityType identityType = logIn.UserName.Contains("@") ? IdentityType.UserPrincipalName : IdentityType.SamAccountName;

                    using PrincipalContext context = new PrincipalContext(ContextType.Domain, domain.Name);
                    if (context != null)
                    {
                        UserPrincipal user = UserPrincipal.FindByIdentity(context, identityType, logIn.UserName);

                        if (user == null)
                        {
                            result = LogInResult.UserNotFound;
                        }
                        else
                        {
                            result = context.ValidateCredentials(user.SamAccountName, logIn.Password) ? LogInResult.Success : LogInResult.WrongCredentials;
                        }
                    }
                }

                return result;
            }
            catch
            {
                return LogInResult.Error;
            }
        }

        /// <summary>
        /// Getting searcher filter for <paramref name="identityValue"/> and <paramref name="identityType"/>
        /// </summary>
        /// <param name="identityValue">Identity value</param>
        /// <param name="identityType">Identity type</param>
        private static string GetFiler(string identityValue, IdentityType identityType)
        {
           /// string email = "julien.lesbats@groupecat.com";//"indramani-kumar.mishra@groupecat.com";
          // return $"(&(objectClass=user)(UserPrincipalName={email}))";
            return $"(&(objectClass=user)({identityType.GetName()}={identityValue}))";
        }
    }
}

using System.DirectoryServices.AccountManagement;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IdentityType" />
    /// </summary>
    public static class IdentityTypeExtensions
    {
        /// <summary>
        /// Getting <paramref name="identityType"/> as string value
        /// </summary>
        /// <param name="identityType"><see cref="IdentityType"/> value</param>
        public static string GetName(this IdentityType identityType)
        {
            return identityType == IdentityType.Sid ? "objectSid" : identityType.ToString();
        }
    }
}

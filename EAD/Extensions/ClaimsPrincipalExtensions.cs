using EAD.Data.Enums;
using System;
using System.Linq;
using System.Security.Claims;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="ClaimsPrincipal" />
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Getting <see cref="string"/> value of <paramref name="claimsPrincipal"/>
        /// </summary>
        /// <param name="claimsPrincipal"><see cref="ClaimsPrincipal"/> object</param>
        /// <param name="propertyName">Property name</param>
        public static string GetString(this ClaimsPrincipal claimsPrincipal, string propertyName)
        {
            if (claimsPrincipal != null)
            {
                return claimsPrincipal.Claims.FirstOrDefault(x => x.Type == propertyName)?.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checking if user is in role <paramref name="permissionType"/>
        /// </summary>
        /// <param name="claimsPrincipal"><see cref="ClaimsPrincipal"/> object</param>
        /// <param name="permissionType">Permission type</param>
        public static bool IsInRole(this ClaimsPrincipal claimsPrincipal, PermissionsType permissionType)
        {
            if (claimsPrincipal != null)
            {
                return permissionType == PermissionsType.Default || claimsPrincipal.Claims.FirstOrDefault(x => x.Type == $"Permissions.{permissionType}" && x.Value.Equals("true", StringComparison.OrdinalIgnoreCase)) != null;
            }
            else
            {
                return false;
            }
        }
    }
}

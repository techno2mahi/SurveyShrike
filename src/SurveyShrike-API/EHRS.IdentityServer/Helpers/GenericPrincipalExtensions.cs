using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace EHRS.Web
{
    /// <summary>
    /// This Extension is added for showing the logged in user's Name instead of user id 
    /// </summary>
    public static class GenericPrincipalExtensions
    {
        public static string FirstName(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "FirstName")
                        return claim.Value;
                }
                return "";
            }
            return "";
        }

        /// <summary>
        /// Returns the access token to be used to authenticate the Web API requests
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string AccessToken(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "AccessToken")
                        return claim.Value;
                }
                return "";
            }
            return "";
        }
    }
}
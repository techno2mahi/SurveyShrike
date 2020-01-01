using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using EHRS.Shared;

namespace EHRS.IdentityServer.Helpers
{
    public static class TokenIdentityHelper
    {
        /// <summary>
        /// Gets the ownerId from token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetOwnerIdFromToken(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            var issuerFromIdentity = "";
            var subFromIdentity = "";
            // var Name = ClaimsPrincipal.Current.Identity.Name;
            if (principal == null)
                return subFromIdentity;
            foreach (Claim claim in principal.Claims)
            {
                if (claim.Type == GlobalConstants.Account.ClaimTypes.Issuer)
                    issuerFromIdentity = claim.Value;//todo not being used now 
                if (claim.Type == GlobalConstants.Account.ClaimTypes.Subject)
                    subFromIdentity = claim.Value;
            }

            return subFromIdentity ?? "";
        }

        public static void FillTokenInfo(object dto, HttpRequestMessage request)
        {
            Dictionary<string, PropertyInfo> props = dto.GetType().GetProperties().ToDictionary(p => p.Name);
            string ownerId = GetOwnerIdFromToken(request);
            if (props.ContainsKey("OwnerId"))
            {
                PropertyInfo p = props["OwnerId"];
                p.SetValue(dto, ownerId);
            }
            if (props.ContainsKey("CreatedBy"))
            {
                PropertyInfo p = props["CreatedBy"];
                p.SetValue(dto, ownerId);
            }
            if (props.ContainsKey("UpdatedBy"))
            {
                PropertyInfo p = props["UpdatedBy"];
                p.SetValue(dto, ownerId);
            }
        }

        public static string GetSingleClickSignInToken(string userId)
        {
            return EncryptionUtility.Encrypt(userId);
        }

        public static string GetUserIdSingleClickSignInToken(string oneClickToken)
        {
            return EncryptionUtility.Decrypt(oneClickToken);
        }

        public static bool IsCredentialForSingleClick(string oneClickToken)
        {
            return oneClickToken.Length > 50;
        }

        public static bool IsAuthorised(HttpRequestMessage request, string ownerId)
        {
            bool isAdmin = IsInRole(request, GlobalConstants.Account.Roles.Admin);
            string userId = GetOwnerIdFromToken(request);
            return isAdmin || userId == ownerId;
        }

        public static string GetUseridFromToken(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            var useridFromIdentity = "";
            if (principal == null)
                return useridFromIdentity;
            foreach (Claim claim in principal.Claims)
            {
                if (claim.Type == GlobalConstants.Account.ClaimTypes.UserName)
                    useridFromIdentity = claim.Value;
            }
            return useridFromIdentity ?? "";
        }

        public static List<Claim> GetUserRolesFromToken(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            List<Claim> userRoles = null;
            if (principal == null)
                return userRoles;
            userRoles = principal.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            return userRoles ?? new List<Claim>();
        }

        private static bool IsInRole(HttpRequestMessage request, string role)
        {
            var retval = false;
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;

            if (principal != null)
            {
                retval = principal.HasClaim(ClaimTypes.Role, role);
            }

            return retval;
        }

        public static bool IsAdmin(HttpRequestMessage request)
        {
            return IsInRole(request, GlobalConstants.Account.Roles.Admin);
        }

        public static bool IsOperator(HttpRequestMessage request)
        {
            return IsInRole(request, GlobalConstants.Account.Roles.Operator);
        }

        public static bool IsUser(HttpRequestMessage request)
        {
            return IsInRole(request, GlobalConstants.Account.Roles.User);
        }
    }
}
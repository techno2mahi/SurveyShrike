using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using EHRS.Shared;

namespace EHRS.WebAPI.Helpers
{
    public static class TokenIdentityHelper
    {
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

        public static Int16 GetSchoolIdFromToken(HttpRequestMessage request)
        {
            ClaimsPrincipal principal = request.GetRequestContext().Principal as ClaimsPrincipal;
            Int16 schoolId = 0;
            if (principal == null)
                return schoolId;
            foreach (Claim claim in principal.Claims)
            {
                if (claim.Type == GlobalConstants.Account.ClaimTypes.SchoolId)
                    schoolId = Convert.ToInt16(claim.Value);
            }
            return schoolId;
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
            return Guid.NewGuid() + "-" + userId + "-" + Guid.NewGuid();//improve the logic
        }

        public static string GetUserIdSingleClickSignInToken(string token)
        {
            return token.Substring(37, 36);//todo improve decrypt logic
        }

        public static bool IsCredentialForSingleClick(string password)
        {
            return password.Length == 110;
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
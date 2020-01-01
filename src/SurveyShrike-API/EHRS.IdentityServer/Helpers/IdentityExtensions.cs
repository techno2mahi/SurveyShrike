﻿using System.Threading.Tasks;
using Microsoft.AspNet.Identity; 
using EHRS.IdentityServer.Models;

namespace EHRS.IdentityServer.Helpers
{
    public static class IdentityExtensions
    {
        public static async Task<ApplicationUser> FindByNameOrEmailAsync
            (this UserManager<ApplicationUser> userManager, string usernameOrEmail, string password)
        {
            var username = usernameOrEmail;
            if (usernameOrEmail.Contains("@"))
            {
                var userForEmail = await userManager.FindByEmailAsync(usernameOrEmail);
                if (userForEmail != null)
                {
                    username =  userForEmail.UserName;
                }
            }
            return await userManager.FindAsync(username, password);
        }


    }
}
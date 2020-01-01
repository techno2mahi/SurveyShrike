using EHRS.Shared;
using EHRS.Web.Shared.Models;
using EHRS.IdentityServer.Entities;
using EHRS.IdentityServer.Helpers;
using EHRS.IdentityServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHRS.IdentityServer
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;
       
        public UserManager<ApplicationUser> UserManager { get; private set; }//todo move models to Web.Shared

        public AuthRepository()
        {
            _ctx = new AuthContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            UserManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);//todo
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser user, string password)
        {
            UserManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);//todo from config
            var result = await UserManager.CreateAsync(user, password);

            // Adds the user to role
            if (result.Succeeded)
            {
                result = UserManager.AddToRole(user.Id, "User");
            }

            return result;
        }

        public async Task<IdentityResult> AddUserToRole(string userId, string role)
        { 
            var result = UserManager.AddToRole(userId, role);
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = null;     

            try
            {
                user  = await UserManager.FindByNameOrEmailAsync(userName, password);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
            }
           
            return user;
        }

        public async Task<AspNetUserProperty> FindUserProperty(string userId)
        {
            AspNetUserProperty userProperty = new AspNetUserProperty();
            try
            {
                userProperty = await _ctx.AspNetUserProperties.FindAsync(userId);               
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
            }
            return userProperty;
        }

        public async Task<IList<string>> FindRolesAsync(string userId)
        {
           var roles = await UserManager.GetRolesAsync(userId);
           return roles;
        }  
        
        public IList<string> FindRoles(string userId)
        {
           var roles =   UserManager.GetRoles(userId);
           return roles;
        } 

        public Client FindClient(string clientId)
        {
            var client = _ctx.Clients.Find(clientId);
            return client;
        }
         
        public async Task<ApplicationUser> FindByUserIdAsync(string userId)
        {
            var result =  await UserManager.FindByIdAsync(userId);
            return result;
        }

        public bool IsLockedOut(string userId)
        {
            var lockOutStatus = UserManager.IsLockedOut(userId);
            return lockOutStatus;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var result = await UserManager.CreateAsync(user);
            // Adds the user to role
            if (result.Succeeded)
            {
                result = UserManager.AddToRole(user.Id, "User");//todo keep in constant
            }

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            UserManager.Dispose();
        }
    }
}
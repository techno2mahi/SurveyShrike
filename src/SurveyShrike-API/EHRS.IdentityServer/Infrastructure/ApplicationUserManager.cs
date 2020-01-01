using EHRS.Shared;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using EHRS.IdentityServer.Models;

namespace EHRS.IdentityServer.Infrastructure
{
    /// <summary>
    /// Application user Manager inheriting from User Manager
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>  
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        } 
   
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<ApplicationDbContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext));
            
            // Configure validation logic for passwords
            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = AppConstants.ConfigurationKeys.RequiredPasswordLength,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    TokenLifespan = TimeSpan.FromHours(AppConstants.ConfigurationKeys.EmailConfirmationLifeTimeInHours)
                };
            }
           
            return appUserManager;
        } 
    }
}
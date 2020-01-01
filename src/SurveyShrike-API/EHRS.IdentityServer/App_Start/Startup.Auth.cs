using System;
using EHRS.Shared;
using EHRS.IdentityServer.Infrastructure;
using EHRS.IdentityServer.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using EHRS.IdentityServer.Models;

namespace EHRS.IdentityServer
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);

            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(GlobalConstants.TokenEndPointPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(AppConstants.ConfigurationKeys.AccessTokenExpireTimeInMinutes)),
                Provider = new SimpleAuthorizationServerProvider() 
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}
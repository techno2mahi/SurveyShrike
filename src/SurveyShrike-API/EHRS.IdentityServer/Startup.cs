using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using EHRS.IdentityServer.Filters;

[assembly: OwinStartupAttribute(typeof(EHRS.IdentityServer.Startup))]
namespace EHRS.IdentityServer
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration(); 

            ConfigureOAuth(app);
            config.Filters.Add(new ValidateModelAttribute());

            WebApiConfig.Register(config);
           
            app.UseWebApi(config);
        }
    }
}
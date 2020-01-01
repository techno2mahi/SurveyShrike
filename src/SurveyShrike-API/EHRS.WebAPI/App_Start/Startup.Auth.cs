using Microsoft.Owin.Security.OAuth;
using Owin;

namespace EHRS.WebAPI
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            //Token Consumption
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}
﻿using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartupAttribute(typeof(EHRS.WebAPI.Startup))]
namespace EHRS.WebAPI
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration(); 

            ConfigureOAuth(app);
            
            WebApiConfig.Register(config);
           
            app.UseWebApi(config);
        }
    }
}
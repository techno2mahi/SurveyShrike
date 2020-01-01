using System.Web.Http;
using EHRS.IdentityServer;
using WebActivatorEx;
using Swashbuckle.Application;
using EHRS.Shared;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace EHRS.IdentityServer
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            if (!AppConstants.ConfigurationKeys.IsDevelopment)
            {
                return;
            }
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SurveyShrike.IdentityServer");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });

        }
    }
}

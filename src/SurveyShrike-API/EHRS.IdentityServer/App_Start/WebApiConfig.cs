using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using EHRS.Shared;
using EHRS.IdentityServer.Helpers;
using System.Web.Http.Tracing;

namespace EHRS.IdentityServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute(AppConstants.ConfigurationKeys.AllowedOrigins, "*", "*");
            config.EnableCors(corsAttr);

            config.Filters.Add(new HandleExceptionFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();
      
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/identity/"+AppConstants.ConfigurationKeys.WebApiVersion+"/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // API Throttling            
            if (AppConstants.ConfigurationKeys.IsThrottlingEnabled)
            {
                var traceWriter = new SystemDiagnosticsTraceWriter()
                {
                    IsVerbose = true
                };
                config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), traceWriter);
                config.EnableSystemDiagnosticsTracing();
            }   

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}

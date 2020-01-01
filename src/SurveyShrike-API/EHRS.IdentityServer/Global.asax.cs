using System.Web.Http;
using System.Web.Mvc;
using EHRS.Shared;

namespace EHRS.IdentityServer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //PositionConsumeService.SetupPositionConsumer();
            
            //EngineContext.Initialize(false);
        }
    }
}

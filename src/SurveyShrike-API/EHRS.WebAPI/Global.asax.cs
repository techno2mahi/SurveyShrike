using EHRS.Shared;
using System.Web.Http;
using System.Web.Mvc; 

namespace EHRS.WebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            EngineContext.Initialize(false);
        }
    }
}

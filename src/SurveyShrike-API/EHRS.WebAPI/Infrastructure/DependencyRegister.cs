using Autofac;
using Autofac.Core;
using EHRS.Shared;
using EHRS.Shared.Caching;
using System.Web;

namespace EHRS.WebAPI.Controllers
{
    public class DependencyRegister : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, EHRSConfig config)
        {
            builder.Register(c =>
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
             

            RegisterControllers(builder);

            RegisterModelBinders(builder);
        }

        private void RegisterControllers(ContainerBuilder builder)
        {

            builder.RegisterType<HealthApiController>()
              .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("ehrs_cache_static"));
        }

        private void RegisterModelBinders(ContainerBuilder builder)
        {
        }
 

        public int Order { get; set; }
    }
}
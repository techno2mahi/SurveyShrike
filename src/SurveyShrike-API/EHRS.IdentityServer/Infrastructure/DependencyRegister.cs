using Autofac;
using Autofac.Core;
using EHRS.IdentityServer.Controllers;
using EHRS.Shared;
using EHRS.Shared.Caching;
using System.Web;

namespace EHRS.IdentityServer.Infrastructure
{
    public class DependencyRegister : IDependencyRegistrar
    {
		private const string ObjectContextName = "ss_object_context_web_api";

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, EHRSConfig config)
        {
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
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
            builder.RegisterType<AccountApiController>().InstancePerLifetimeScope();

            builder.RegisterType<HealthApiController>()
               .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("ehrs_cache_static"))
               .InstancePerLifetimeScope(); 
        }

        private void RegisterModelBinders(ContainerBuilder builder)
        {
        }

        public int Order { get; set; }
    }
}
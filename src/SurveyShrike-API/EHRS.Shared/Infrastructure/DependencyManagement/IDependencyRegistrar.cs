using Autofac;

namespace EHRS.Shared
{
    /// <summary>
    /// Dependency registrar interface
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, EHRSConfig config);

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        int Order {
            get  ;
        }
    }
}

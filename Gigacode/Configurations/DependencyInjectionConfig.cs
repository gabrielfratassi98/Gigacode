using Gigacode.Infra.CrossCuting.DependencyInjection;

namespace Gigacode.Services.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServicesInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException();

            NativeDependencyInjection.AddNativeDependencyInjection(services);
        }
    }
}

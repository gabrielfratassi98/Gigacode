using Gigacode.Infra.CrossCuting.DependencyInjection;

namespace Gigacode.Services.ConfigurationsServices
{
    public static class DependencyInjection
    {
        public static void RegisterServicesInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException();

            NativeDependencyInjection.AddNativeDependencyInjection(services);
        }
    }
}

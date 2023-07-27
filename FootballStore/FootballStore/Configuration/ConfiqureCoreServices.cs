using FootballStore.Core.Interfaces;
using FootballStore.Infrastructure;

namespace FootballStore.Configuration
{
    public static class ConfiqureCoreServices
    {
        internal static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}

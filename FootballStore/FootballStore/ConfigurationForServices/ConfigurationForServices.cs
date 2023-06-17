using FootballStore.Core.Interfaces.IRepository;
using FootballStore.Core.Interfaces.Services;
using FootballStore.Infrastructure.Data;
using FootballStore.Services;
using Microsoft.EntityFrameworkCore;

namespace FootballStore.ConfigurationForServices
{
    public static class ConfigurationForServices
    {
        internal static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {

            services.AddDbContext<CatalogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure()),
                ServiceLifetime.Scoped);            

            services.AddScoped(typeof(ICatalogService), typeof(CatalogService));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));


        }
    }
}

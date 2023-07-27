using FootballStore.Infrastructure.Data;
using FootballStore.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballStore.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<CatalogContext>(context => context.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));
            services.AddDbContext<AppIdentityDbContext>(context => context.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}

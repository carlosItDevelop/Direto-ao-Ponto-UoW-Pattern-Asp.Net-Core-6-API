using Cooperchip.DiretoAoPonto.Data.Orm;
using Microsoft.EntityFrameworkCore;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, 
                                                                 IConfiguration configuration)
        {
            services.AddDbContext<UoWDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

    }
}

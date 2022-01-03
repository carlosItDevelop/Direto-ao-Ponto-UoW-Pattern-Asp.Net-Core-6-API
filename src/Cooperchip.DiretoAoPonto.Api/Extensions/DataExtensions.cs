using Cooperchip.DiretoAoPonto.Data.FailedRepository;
using Cooperchip.DiretoAoPonto.Data.FailedRepository.Abstraction;
using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Data.Repositories;

namespace Cooperchip.DiretoAoPonto.Uow.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UowDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IVooFailedRepository, VooFailedRepository>();
            services.AddScoped<IPessoaFailedRepository, PessoaFailedRepository>();

            services.AddScoped<IVooRepository, VooRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            return services;
        }

    }
}

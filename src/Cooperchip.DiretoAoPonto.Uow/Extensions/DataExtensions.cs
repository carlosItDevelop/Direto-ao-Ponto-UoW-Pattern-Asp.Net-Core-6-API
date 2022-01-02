﻿using Cooperchip.DiretoAoPonto.Data.Orm;
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
            services.AddScoped<IVooRepository, VooRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            return services;
        }

    }
}

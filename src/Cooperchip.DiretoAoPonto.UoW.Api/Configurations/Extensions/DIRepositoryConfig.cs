using Cooperchip.DiretoAoPonto.Data.FailedRepository;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction;
using Cooperchip.DiretoAoPonto.Data.Repositories.Implementations;
using Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations;
using Cooperchip.DiretoAoPonto.Data.Repositories.V2.Implementations;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions
{
    public static class DIRepositoryConfig
    {
        public static IServiceCollection AddDIRepositoryConfig(this IServiceCollection services)
        {

            services.AddScoped<IPessoaFailedRepository, PessoaFailedRepository>();
            services.AddScoped<IVooFailedRepository, VooFailedRepository>();

            services.AddScoped<IPessoaRepository, PessoaReposiory>();
            services.AddScoped<IVooRepository, VooRepository>();

            // V2 Approach
            services.AddScoped<IPessoaV2Repository, PessoaV2Repository>();
            services.AddScoped<IVooV2Repository, VooV2Repository>();
            services.AddScoped<IUnitOfW, UnitOfW>();

            return services;

        }
    }
}

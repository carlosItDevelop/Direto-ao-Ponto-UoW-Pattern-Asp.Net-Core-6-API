using Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Settings;
using Microsoft.Extensions.Options;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions
{
    public static class AppSettingsConfig
    {

        public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services,
                                                                         IConfiguration configuration)
        {
            services.Configure<VooSettings>(configuration.GetSection(VooSettings.SessionName));
            services.AddSingleton(s => s.GetRequiredService<IOptions<VooSettings>>().Value);

            return services;
        }
    }
}

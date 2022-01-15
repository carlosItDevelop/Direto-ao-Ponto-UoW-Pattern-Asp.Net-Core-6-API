using Microsoft.OpenApi.Models;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Direto ao Ponto, UoW - API",
                    Description = "Esta API serve recursos do Sistema para testar o Unit Of Work Pattrn",
                    Contact = new OpenApiContact()
                    {
                        Name = "Carlos A Santos",
                        Email = "carlos.itdeveloper@gmail.com",
                        Url = new Uri("https://cooperchip.com.br")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                }));

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unit Of Work v1"));

            return app;
        }

    }
}

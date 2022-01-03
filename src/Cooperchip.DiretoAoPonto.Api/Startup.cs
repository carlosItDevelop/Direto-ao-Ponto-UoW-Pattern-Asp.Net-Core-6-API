using Cooperchip.DiretoAoPonto.Api.Mapper;
using Cooperchip.DiretoAoPonto.Uow.Extensions;
using Microsoft.OpenApi.Models;

namespace Cooperchip.DiretoAoPonto.Uow
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddContexts(Configuration);
            services.AddRepositories();

            services.AddControllers();
            services.AddSwaggerGen(opt =>
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Direto ao Ponto, UoW - API",
                    Description = "Esta API serve recursos do Sistema para testar o unit Of Work Design",
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
                })
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnitOfWork v1"));

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

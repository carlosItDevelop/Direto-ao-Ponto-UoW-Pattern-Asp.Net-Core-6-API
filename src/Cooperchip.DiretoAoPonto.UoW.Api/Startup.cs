using Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions;
using Cooperchip.DiretoAoPonto.UoW.Api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.UoW.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configureservices(IServiceCollection services)
        {

            services.AddApiVersioning(opt => {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(opt => {
                opt.GroupNameFormat = "'v'VV";
                opt.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(opt => { 
                opt.SuppressModelStateInvalidFilter = true;
            });


            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddDIRepositoryConfig();
            services.AddDbContextConfig(Configuration);
            services.AddSwaggerConfig();
            services.AddAppSettingsConfig(Configuration);

            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfig();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}

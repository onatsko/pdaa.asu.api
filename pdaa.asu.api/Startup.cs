using Dapper.FluentMap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.ModelMaps;
using pdaa.asu.api.Services;
using System.Net.Http;

namespace pdaa.asu.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Required for HttpClient support in the Blazor Client project
            services.AddHttpClient();
            services.AddScoped<HttpClient>();
            // Pass settings to other components
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(Configuration["ConnectionString"]));

            //services.AddScoped<ServiceScheduler>();
            //services.AddScoped<ServiceCommon>();
            //services.AddScoped<ServiceStudentOffice_DisciplineSelect>();
            //services.AddScoped<ServicePulse>();
            //services.AddScoped<ServiceTests>();

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new MapKadr());
                config.AddMap(new MapMoving());
                config.AddMap(new MapGroup());
                config.AddMap(new MapPosada());
                config.AddMap(new MapKafedra());
                config.AddMap(new MapEducPlanSpec());
                config.AddMap(new MapDisciplineSelected());
                config.AddMap(new MapLogOnd());
                config.AddMap(new MapTelegramBotHistory());
                config.AddMap(new MapTest_Shablon());
                config.AddMap(new MapTest_ShablonDetail());
                config.AddMap(new MapTest_StartedTestQuestion());
                config.AddMap(new MapTest_StartedTestAnswer());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

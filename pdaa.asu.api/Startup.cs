using System;
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
using pdaa.asu.api.JwsAuthentication;
using Microsoft.IdentityModel.Tokens;

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

            //current user всегда scoped!!
            //services.AddScoped<ServiceCurrentUser>();

            services.AddScoped<IServiceAuthentication, ServiceAuthentication>();
            services.AddScoped<ServiceScheduler>();
            services.AddScoped<ServiceCommon>();
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

            //*** JWT
            const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
            var signingKey = new SigningSymmetricKey(signingSecurityKey);
            services.AddSingleton<IJwtSigningEncodingKey>(signingKey);
            //*** JWT

            services.AddControllers();

            //*** JWT 
            const string jwtSchemeName = "JwtBearer";
            var signingDecodingKey = (IJwtSigningDecodingKey)signingKey;
            services
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = jwtSchemeName;
                    options.DefaultChallengeScheme = jwtSchemeName;
                })
                .AddJwtBearer(jwtSchemeName, jwtBearerOptions => {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingDecodingKey.GetKey(),

                        ValidateIssuer = true,
                        ValidIssuer = "pdaa.asu.api",

                        ValidateAudience = true,
                        ValidAudience = "pdaa.asu.client",

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.FromSeconds(5)
                    };
                });
            //*** JWT
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
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

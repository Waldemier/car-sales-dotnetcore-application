using System.IO;
using CarSales.Domain.Interfaces.Other;
using CarSales.Infrastructure;
using CarSales.Infrastructure.Extensions;
using CarSales.UI.ActionFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;

namespace CarSales.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureControllers(); // custom

            // validator services
            services.AddScoped<ValidateOfferExistsAttribute>();
            services.AddScoped<ValidateUserExistsAttribute>();
            // DI
            services.AddCustomLogger();
            services.ConfigureJWT(Configuration);
            services.ConfigureAutoMapper();
            services.CorsConfiguration();
            services.ConfigurationDbContext(Configuration);
            services.UnitOfWorkConfiguration();
            services.ServiceManagerConfiguration();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CarSales.UI", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarSales.UI v1"));
            }

            app.ConfigureExceptionHandler(logger); // custom exception middleware
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
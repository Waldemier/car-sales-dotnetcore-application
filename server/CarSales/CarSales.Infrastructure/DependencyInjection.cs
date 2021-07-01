using System;
using System.Reflection;
using System.Text;
using CarSales.Application;
using CarSales.Application.FluentValidators.Auth;
using CarSales.Application.Services;
using CarSales.Domain;
using CarSales.Domain.Interfaces.Other;
using CarSales.EFData;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarSales.Infrastructure.Security;
using CarSales.LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CarSales.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCustomLogger(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
        
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secure)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero // How much time after completion it can still be used
                };
            });
        }
        
        public static void ConfigureAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        public static void ConfigureControllers(this IServiceCollection services) =>
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginDtoValidator>());
        
        public static void ServiceManagerConfiguration(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        
        public static void UnitOfWorkConfiguration(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        public static void CorsConfiguration(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CarSalesPolicy", policy => 
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials()
                    );
            });
        
        public static void ConfigurationDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                    x => x.MigrationsAssembly("CarSales.EFData")));
    }
}
using CarSales.Domain;
using CarSales.EFData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Infrastructure
{
    public static class DependencyInjection
    {
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
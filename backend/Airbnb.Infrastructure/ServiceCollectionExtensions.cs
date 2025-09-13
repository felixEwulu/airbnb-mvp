using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Airbnb.Infrastructure.Persistence; // Make sure this points to your AirbnbDbContext namespace

namespace Airbnb.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Use the connection string from appsettings.json
            var connectionString = config.GetConnectionString("AirbnbDb");

            // Register AirbnbDbContext for dependency injection
            services.AddDbContext<AirbnbDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}

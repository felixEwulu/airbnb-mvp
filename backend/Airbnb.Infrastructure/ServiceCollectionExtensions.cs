using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Airbnb.Infrastructure.Persistence;
using Airbnb.Domain.Repositories;
using Airbnb.Infrastructure.Repositories;

namespace Airbnb.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Use the connection string from appsettings.json
            var connectionString = config.GetConnectionString("AirbnbDb");

            // Register DbContext
            services.AddDbContext<AirbnbDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // TODO: Add other repositories when you create them
            // services.AddScoped<IPropertyRepository, PropertyRepository>();

            return services;
        }
    }
}

// File: Persistence/AirbnbDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Airbnb.Infrastructure.Persistence
{
    public class AirbnbDbContextFactory : IDesignTimeDbContextFactory<AirbnbDbContext>
    {
        public AirbnbDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AirbnbDbContext>();
            
            // Use your SQL Server connection string here
            optionsBuilder.UseSqlServer("Server=localhost;Database=AirbnbDb;Trusted_Connection=True;");

            return new AirbnbDbContext(optionsBuilder.Options);
        }
    }
}

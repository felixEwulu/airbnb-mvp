// File: Airbnb.Infrastructure/Persistence/AirbnbDbContext.cs
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure.Persistence
{
    public class AirbnbDbContext : DbContext
    {
        public AirbnbDbContext(DbContextOptions<AirbnbDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirbnbDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

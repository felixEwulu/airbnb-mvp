// File: Airbnb.Infrastructure/Persistence/Configurations/PropertyConfiguration.cs
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(ad => ad.Street).IsRequired().HasMaxLength(200);
                a.Property(ad => ad.City).IsRequired().HasMaxLength(100);
                a.Property(ad => ad.State).IsRequired().HasMaxLength(100);
                a.Property(ad => ad.Country).IsRequired().HasMaxLength(100);
                a.Property(ad => ad.ZipCode).IsRequired().HasMaxLength(20);
            });

            // Relationship with bookings
            builder.HasMany(p => p.Bookings)
                   .WithOne() // Booking.PropertyId is FK
                   .HasForeignKey(b => b.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

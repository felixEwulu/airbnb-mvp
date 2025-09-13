// File: Airbnb.Infrastructure/Persistence/Configurations/UserConfiguration.cs
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            // Relationships
            builder.HasMany(u => u.Properties)
                   .WithOne() // Owner navigation is in Property, can be shadow property
                   .HasForeignKey(p => p.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Bookings)
                   .WithOne() // Booking.UserId is foreign key
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

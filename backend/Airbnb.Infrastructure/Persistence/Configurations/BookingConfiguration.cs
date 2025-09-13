// File: Airbnb.Infrastructure/Persistence/Configurations/BookingConfiguration.cs
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.StartDate).IsRequired();
            builder.Property(b => b.EndDate).IsRequired();

            builder.OwnsOne(b => b.Price, p =>
            {
                p.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)");
                p.Property(x => x.Currency).IsRequired().HasMaxLength(3);
            });

            // Relationship with payments
            builder.HasMany(b => b.Payments)
                   .WithOne()
                   .HasForeignKey(p => p.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

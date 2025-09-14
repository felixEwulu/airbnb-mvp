// File: Airbnb.Infrastructure/Persistence/Configurations/PaymentConfiguration.cs
using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Amount, a =>
            {
                a.Property(m => m.Amount).IsRequired().HasColumnType("decimal(18,2)");
                a.Property(m => m.Currency).IsRequired().HasMaxLength(3);
            });

            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}

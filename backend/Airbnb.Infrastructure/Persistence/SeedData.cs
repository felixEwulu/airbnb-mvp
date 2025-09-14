using Airbnb.Domain.Entities;
using Airbnb.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure.Persistence;

public static class SeedData
{
    public static void Initialize(AirbnbDbContext context)
    {
        // Ensure database exists
        context.Database.EnsureCreated();

        // Seed Users
        if (!context.Users.Any())
        {
            var newUsers = new List<User>
            {
                new User("Alice", "alice@example.com", "08012345678"),
                new User("Bob", "bob@example.com", "08087654321")
            };

            context.Users.AddRange(newUsers);
            context.SaveChanges();
        }

        // Fetch users from DB to use in properties/bookings
        var user1 = context.Users.First(u => u.Email == "alice@example.com");
        var user2 = context.Users.First(u => u.Email == "bob@example.com");

        // Seed Properties
        if (!context.Properties.Any())
        {
            var property1 = new Property(
                "Luxury Apartment",
                new Address("123 Main St", "Lagos", "Lagos State", "Nigeria", "101001"),
                user1.Id // ownerId
            );

            var property2 = new Property(
                "Cozy Studio",
                new Address("456 Elm St", "Abuja", "FCT", "Nigeria", "900001"),
                user2.Id // ownerId
            );

            context.Properties.AddRange(property1, property2);
            context.SaveChanges();

            // Seed Bookings
            var booking1 = new Booking(
                user1.Id,
                property1.Id,
                DateTime.Now,
                DateTime.Now.AddDays(3),
                new Money(150m, "USD")
            );

            var booking2 = new Booking(
                user2.Id,
                property2.Id,
                DateTime.Now,
                DateTime.Now.AddDays(2),
                new Money(80m, "USD")
            );

            context.Bookings.AddRange(booking1, booking2);
            context.SaveChanges();
        }
    }
}

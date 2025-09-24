using Airbnb.Domain.Entities;
using Airbnb.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infrastructure.Persistence;

public static class SeedData
{
    public static void Initialize(AirbnbDbContext context)
    {
        // Apply migrations (instead of EnsureCreated)
        context.Database.Migrate();

        // ---- Seed Users ----
        if (!context.Users.Any())
        {
            var newUsers = new List<User>
            {
                new User(
                    fullName: "Alice Johnson",
                    email: "alice@example.com",
                    phoneNumber: "08012345678"
                ),
                new User(
                    fullName: "Bob Smith",
                    email: "bob@example.com",
                    phoneNumber: "08087654321"
                )
            };

            context.Users.AddRange(newUsers);
            context.SaveChanges();
        }

        // Fetch users from DB
        var user1 = context.Users.First(u => u.Email == "alice@example.com");
        var user2 = context.Users.First(u => u.Email == "bob@example.com");

        // ---- Seed Properties ----
        if (!context.Properties.Any())
        {
            var property1 = new Property(
                title: "Luxury Apartment",
                address: new Address("123 Main St", "Lagos", "Lagos State", "Nigeria", "101001"),
                ownerId: user1.Id
            );

            var property2 = new Property(
                title: "Cozy Studio",
                address: new Address("456 Elm St", "Abuja", "FCT", "Nigeria", "900001"),
                ownerId: user2.Id
            );

            context.Properties.AddRange(property1, property2);
            context.SaveChanges();

           // Seed Bookings
var booking1 = new Booking(
    property1.Id,       // PropertyId
    user1.Id,           // UserId
    DateTime.UtcNow,    // StartDate
    DateTime.UtcNow.AddDays(3), // EndDate
    new Money(150m, "USD")      // Price
);

var booking2 = new Booking(
    property2.Id,       // PropertyId
    user2.Id,           // UserId
    DateTime.UtcNow,    // StartDate
    DateTime.UtcNow.AddDays(2), // EndDate
    new Money(80m, "USD")       // Price
);

context.Bookings.AddRange(booking1, booking2);
context.SaveChanges();

        }
    }
}

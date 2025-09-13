// File: Airbnb.Domain/Entities/User.cs
using System;
using System.Collections.Generic;

namespace Airbnb.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }

        // Relationships
        private readonly List<Property> _properties = new();
        public IReadOnlyCollection<Property> Properties => _properties.AsReadOnly();

        private readonly List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

        private User() { } // EF Core

        public User(string fullName, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name is required", nameof(fullName));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Valid email is required", nameof(email));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required", nameof(phoneNumber));

            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
        }

        // --- Behaviors ---

        public Property AddProperty(string title, ValueObjects.Address address)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Property title is required", nameof(title));

            var property = new Property(title, address, Id);
            _properties.Add(property);
            return property;
        }

        public Booking AddBooking(Guid propertyId, DateTime startDate, DateTime endDate, ValueObjects.Money price)
        {
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date", nameof(endDate));

            var booking = new Booking(propertyId, Id, startDate, endDate, price);
            _bookings.Add(booking);
            return booking;
        }
    }
}

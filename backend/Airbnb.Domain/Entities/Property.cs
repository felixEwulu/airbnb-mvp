// File: Airbnb.Domain/Entities/Property.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Airbnb.Domain.ValueObjects;

namespace Airbnb.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = default!;
        public Address Address { get; private set; } = default!;
        public Guid OwnerId { get; private set; }

        private readonly List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

        private Property() { }

        public Property(string title, Address address, Guid ownerId)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required", nameof(title));
            if (address == null) throw new ArgumentException("Address is required", nameof(address));

            Id = Guid.NewGuid();
            Title = title;
            Address = address;
            OwnerId = ownerId;
        }

        public Booking CreateBooking(Guid userId, DateTime startDate, DateTime endDate, Money price)
        {
            if (endDate <= startDate) throw new ArgumentException("End date must be after start date");

            bool overlap = _bookings.Any(b => b.Overlaps(startDate, endDate));
            if (overlap) throw new InvalidOperationException("Booking dates overlap with an existing booking");

            var booking = new Booking(Id, userId, startDate, endDate, price);
            _bookings.Add(booking);
            return booking;
        }
    }
}

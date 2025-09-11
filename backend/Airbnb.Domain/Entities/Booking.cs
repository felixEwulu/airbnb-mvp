// File: Airbnb.Domain/Entities/Booking.cs
using System;
using System.Collections.Generic;
using Airbnb.Domain.ValueObjects;

namespace Airbnb.Domain.Entities
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public class Booking
    {
        public Guid Id { get; private set; }
        public Guid PropertyId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Money Price { get; private set; } = default!;
        public BookingStatus Status { get; private set; }

        private readonly List<Payment> _payments = new();
        public IReadOnlyCollection<Payment> Payments => _payments.AsReadOnly();

        private Booking() { }

        public Booking(Guid propertyId, Guid userId, DateTime startDate, DateTime endDate, Money price)
        {
            if (endDate <= startDate) throw new ArgumentException("End date must be after start date");

            Id = Guid.NewGuid();
            PropertyId = propertyId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            Price = price ?? throw new ArgumentException("Price is required", nameof(price));
            Status = BookingStatus.Pending;
        }

        public bool Overlaps(DateTime start, DateTime end) =>
            !(end <= StartDate || start >= EndDate);

        public void Confirm() => Status = BookingStatus.Confirmed;
        public void Cancel() => Status = BookingStatus.Cancelled;

        public Payment MakePayment(Money amount)
        {
            if (Status == BookingStatus.Cancelled)
                throw new InvalidOperationException("Cannot process payment for a cancelled booking");

            var payment = new Payment(Id, amount);
            _payments.Add(payment);
            return payment;
        }
    }
}

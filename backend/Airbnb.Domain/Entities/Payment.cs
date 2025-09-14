// File: Airbnb.Domain/Entities/Payment.cs
using System;
using Airbnb.Domain.ValueObjects;

namespace Airbnb.Domain.Entities
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }

    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid BookingId { get; private set; }
        public Money Amount { get; private set; } = default!;
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Payment() { } // EF Core

        public Payment(Guid bookingId, Money amount)
        {
            if (amount == null) throw new ArgumentException("Amount is required", nameof(amount));

            Id = Guid.NewGuid();
            BookingId = bookingId;
            Amount = amount;
            Status = PaymentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkCompleted() => Status = PaymentStatus.Completed;
        public void MarkFailed() => Status = PaymentStatus.Failed;
    }
}

// File: Airbnb.Domain/ValueObjects/Money.cs
using System;

namespace Airbnb.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = default!;

        private Money() { }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative", nameof(amount));
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("Currency is required", nameof(currency));

            Amount = amount;
            Currency = currency.ToUpper();
        }

        public override string ToString() => $"{Currency} {Amount:N2}";
    }
}

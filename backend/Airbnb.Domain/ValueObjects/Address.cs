using System;

namespace Airbnb.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string State { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public string ZipCode { get; private set; } = default!;

        private Address() { } // For EF Core

        public Address(string street, string city, string state, string country, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street is required", nameof(street));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City is required", nameof(city));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country is required", nameof(country));
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentException("ZipCode is required", nameof(zipCode));

            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public override string ToString() => $"{Street}, {City}, {State}, {Country}, {ZipCode}";
    }
}

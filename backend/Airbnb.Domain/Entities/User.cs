// File: Airbnb.Domain/Entities/User.cs
using System;

namespace Airbnb.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = default!;
        public string Email { get; private set; } = default!;

        private User() { }

        public User(string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name is required", nameof(fullName));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) throw new ArgumentException("Valid email is required", nameof(email));

            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
        }
    }
}

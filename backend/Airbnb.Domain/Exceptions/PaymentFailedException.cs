using System;

namespace Airbnb.Domain.Exceptions
{
    public class PaymentFailedException : Exception
    {
        public PaymentFailedException(string message)
            : base(message) { }
    }
}

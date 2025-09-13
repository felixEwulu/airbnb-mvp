using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Repositories;

namespace Airbnb.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<Payment> AddAsync(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetLatestPaymentForBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetPaymentsByBookingIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetPaymentsInDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetPendingPaymentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalRevenueAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
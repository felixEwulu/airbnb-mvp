using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Repositories
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);

        Task<IEnumerable<Payment>> GetPaymentsByBookingIdAsync(int bookingId);

        Task<Payment?> GetLatestPaymentForBookingAsync(int bookingId);

        Task<decimal> GetTotalRevenueAsync();

        Task<IEnumerable<Payment>> GetPaymentsInDateRangeAsync(DateTime startDate, DateTime endDate);

        Task<IEnumerable<Payment>> GetPendingPaymentsAsync();
    }
}

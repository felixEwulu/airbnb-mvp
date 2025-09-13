using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Repositories;


namespace Airbnb.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public Task<Booking> AddAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsByPropertyIdAsync(int propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
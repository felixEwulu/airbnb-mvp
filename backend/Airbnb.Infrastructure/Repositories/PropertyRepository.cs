using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb.Domain.Entities;
using Airbnb.Domain.Repositories;

namespace Airbnb.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public Task<Property> AddAsync(Property entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountPropertiesByHostIdAsync(int hostId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetAvailablePropertiesAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Property?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertiesByHostIdAsync(int hostId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertiesByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetTopRatedPropertiesAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> SearchByLocationAsync(string location)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
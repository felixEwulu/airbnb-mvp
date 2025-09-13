using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Repositories
{
    public interface IPropertyRepository : IBaseRepository<Property>
    {
        Task<IEnumerable<Property>> GetPropertiesByHostIdAsync(int hostId);
        Task<IEnumerable<Property>> SearchByLocationAsync(string location);

        Task<IEnumerable<Property>> GetPropertiesByPriceRangeAsync(decimal minPrice, decimal maxPrice);

        Task<IEnumerable<Property>> GetAvailablePropertiesAsync(DateTime startDate, DateTime endDate);

        Task<IEnumerable<Property>> GetTopRatedPropertiesAsync(int count);

        Task<IEnumerable<Property>> GetPropertiesByTypeAsync(string type);
        Task<int> CountPropertiesByHostIdAsync(int hostId);
    }
}

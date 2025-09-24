using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airbnb.Domain.Entities;

namespace Airbnb.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetByNameAsync(string name);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
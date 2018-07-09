using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP.Demo.Domain.Models.Identity;
using LinqSpecs;

namespace HP.Demo.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(Specification<User> specification = null);
        Task<User> GetByIdAsync(Guid id);
        void Insert(User user);
        void Update(User user);
        void Remove(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HP.Demo.DataAccess.Contexts;
using HP.Demo.Domain.Contracts;
using HP.Demo.Domain.Models.Identity;
using LinqSpecs;
using Microsoft.EntityFrameworkCore;

namespace HP.Demo.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IQueryable<User> Query => _context.Set<User>().Include("_userGroups.Group");

        public async Task<IEnumerable<User>> GetAllAsync(Specification<User> specification = null)
        {
            var query = Query;

            if (specification != null)
            {
                query = query.Where(specification);
            }

            return await query.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await Query.SingleAsync(u => u.Id == id);
        }

        public void Insert(User user)
        {
            _context.Set<User>().Add(user);
        }

        public void Update(User user)
        {
            _context.Set<User>().Update(user);
        }

        public void Remove(User user)
        {
            _context.Remove(user);
        }
    }
}

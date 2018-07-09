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
    public class GroupRepository : IGroupRepository
    {
        private readonly UserContext _context;

        public GroupRepository(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Group>> GetBySpecAsync(Specification<Group> specification = null)
        {
            var query = _context.Set<Group>().AsQueryable();

            if (specification != null)
            {
                query = query.Where(specification);
            }

            return await query.ToListAsync();
        }
    }
}

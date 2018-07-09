using System;
using System.Threading.Tasks;
using HP.Demo.DataAccess.Contexts;
using HP.Demo.Domain.Contracts;

namespace HP.Demo.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;

        public UnitOfWork(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

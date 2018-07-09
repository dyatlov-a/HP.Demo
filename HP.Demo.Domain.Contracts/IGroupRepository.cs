using System.Collections.Generic;
using System.Threading.Tasks;
using HP.Demo.Domain.Models.Identity;
using LinqSpecs;

namespace HP.Demo.Domain.Contracts
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetBySpecAsync(Specification<Group> specification = null);
    }
}

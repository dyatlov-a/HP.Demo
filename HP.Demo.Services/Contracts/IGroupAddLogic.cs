using System.Threading.Tasks;
using HP.Demo.Domain.Models.Identity;
using LinqSpecs;

namespace HP.Demo.Services.Contracts
{
    public interface IGroupAddLogic
    {
        Task UserAddToGroupsAsync(User user, Specification<Group> spec);
    }
}

using System;
using System.Threading.Tasks;

namespace HP.Demo.Services.Contracts
{
    public interface IGroupService
    {
        Task AddToAdminAsync(Guid userId);
        Task RemoveFromAdminAsync(Guid userId);
    }
}

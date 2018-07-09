using System.Threading.Tasks;

namespace HP.Demo.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}

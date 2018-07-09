using System.Threading.Tasks;
using HP.Demo.Dtos;
using HP.Demo.Services.Common;

namespace HP.Demo.Services.Contracts
{
    public interface IAuthService
    {
        Task<AuthResult> AuthAsync(LoginDto login);
    }
}

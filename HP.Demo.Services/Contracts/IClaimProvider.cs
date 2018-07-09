using System.Security.Claims;
using HP.Demo.Domain.Models.Identity;

namespace HP.Demo.Services.Contracts
{
    public interface IClaimProvider
    {
        Claim[] GetClaims(User user);
    }
}

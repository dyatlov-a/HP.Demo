using System.Collections.Generic;
using System.Security.Claims;

namespace HP.Demo.Services.Contracts
{
    public interface ITokenFactory
    {
        string Create(IEnumerable<Claim> claims);
    }
}

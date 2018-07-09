using System;
using System.Linq;
using System.Threading.Tasks;
using HP.Demo.Domain.Contracts;
using HP.Demo.Domain.Models.Identity.Specifications;
using HP.Demo.Dtos;
using HP.Demo.Services.Common;
using HP.Demo.Services.Contracts;

namespace HP.Demo.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenFactory _tokenFactory;
        private readonly IClaimProvider _claimProvider;
        private readonly IHashService _hashService;

        public AuthService(IUserRepository userRepository,
            ITokenFactory tokenFactory,
            IClaimProvider claimProvider,
            IHashService hashService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));
            _claimProvider = claimProvider ?? throw new ArgumentNullException(nameof(claimProvider));
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        private async Task<AuthResult> AuthActionAsync(LoginDto login)
        {
            var users = (await _userRepository.GetAllAsync(new UserByEmailSpec(login.Email))).ToArray();

            if (users.Length != 1)
                return AuthResult.Fail();

            var targetUser = users[0];
            if (!_hashService.Compare(targetUser, login.Password))
                return AuthResult.Fail();

            var claims = _claimProvider.GetClaims(targetUser);
            return AuthResult.Success(claims, _tokenFactory.Create(claims));
        }

        public Task<AuthResult> AuthAsync(LoginDto login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            return AuthActionAsync(login);
        }
    }
}

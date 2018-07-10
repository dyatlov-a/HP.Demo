using System;
using System.Threading.Tasks;
using HP.Demo.Dtos;
using HP.Demo.Services.Contracts;
using HP.Demo.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HP.Demo.Web.Controllers
{
    public class AuthController : BaseV1Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost]
        public async Task<IActionResult> Token(LoginDto login)
        {
            var token = await _authService.AuthAsync(login);
            if (!token.IsValid)
                return BadRequest("Email or password is not valid");

            return Ok(token);
        }
    }
}


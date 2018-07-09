using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HP.Demo.Services.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace HP.Demo.Web.Infrastructure.Auth
{
    public class TokenFactory : ITokenFactory
    {
        private readonly SecurityOptions _securityOptions;

        public TokenFactory(SecurityOptions securityOptions)
        {
            _securityOptions = securityOptions ?? throw new ArgumentNullException(nameof(securityOptions));
        }

        public string Create(IEnumerable<Claim> claims)
        {
            if (claims == null)
                throw new ArgumentNullException(nameof(claims));

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: _securityOptions.Issuer,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromSeconds(_securityOptions.LifetimeInSeconds)),
                signingCredentials: new SigningCredentials(_securityOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}

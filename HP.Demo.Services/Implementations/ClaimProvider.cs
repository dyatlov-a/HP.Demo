using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Services.Contracts;

namespace HP.Demo.Services.Implementations
{
    public class ClaimProvider : IClaimProvider
    {
        private static readonly Array Functionals = Enum.GetValues(typeof(Functional));

        public Claim[] GetClaims(User user)
        {
            var userFunctionals = user.Groups.Select(g => g.Functionals).ToArray();
            var targetFunctionals = new List<Functional>(Functionals.Length);

            foreach (Functional functional in Functionals)
            {
                if (userFunctionals.Any(uf => (uf & functional) == functional))
                {
                    targetFunctionals.Add(functional);
                }
            }

            var claims = targetFunctionals
                .Select(t => new Claim(nameof(Functional), t.ToString()))
                .Union(new[] { new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email) })
                .ToArray();

            return claims;
        }
    }
}

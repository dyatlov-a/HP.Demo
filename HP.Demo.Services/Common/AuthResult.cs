using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace HP.Demo.Services.Common
{
    public class AuthResult
    {
        public bool IsValid { get; private set; }

        public IEnumerable<KeyValuePair<string, string>> Claims { get; private set; }
        public string Token { get; private set; }

        private AuthResult(bool isValid, 
            Claim[] claims,
            string token)
        {
            IsValid = isValid;
            Token = token;
            Fill(claims);
        }

        private void Fill(Claim[] claims)
        {
            Claims = claims.Select(c => new KeyValuePair<string, string>(c.Type, c.Value));
        }

        public static AuthResult Success(Claim[] claims, string token)
        {
            if (claims == null)
                throw new ArgumentNullException(nameof(claims));
            if (String.IsNullOrWhiteSpace(token))
                throw new ArgumentException(nameof(token));

            return new AuthResult(true, claims, token);
        }

        public static AuthResult Fail()
        {
            return new AuthResult(false, new Claim[0], String.Empty);
        }
    }
}


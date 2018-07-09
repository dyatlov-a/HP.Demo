using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HP.Demo.Web.Infrastructure.Auth
{
    public class SecurityOptions
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int LifetimeInSeconds { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}

using System;
using HP.Demo.Domain.DataContracts;

namespace HP.Demo.Security.Common
{
    public class Password : IPassword
    {
        public byte[] Salt { get; private set; }
        public byte[] Hash { get; private set; }

        public Password(byte[] salt, byte[] hash)
        {
            Salt = salt ?? throw new ArgumentNullException(nameof(salt));
            Hash = hash ?? throw new ArgumentNullException(nameof(hash));
        }
    }
}

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CryptSharp.Utility;
using HP.Demo.Domain.DataContracts;
using HP.Demo.Security.Common;
using HP.Demo.Services.Contracts;

namespace HP.Demo.Security.Implementations
{
    public class HashService : IHashService
    {
        private readonly HashOptions _hashOptions;
        private readonly RandomNumberGenerator _rng = new RNGCryptoServiceProvider();

        public HashService(HashOptions hashOptions)
        {
            _hashOptions = hashOptions ?? throw new ArgumentNullException(nameof(hashOptions));
        }

        private byte[] SaltPassword(string plainPassword)
        {
            var result = Encoding.Unicode.GetBytes(plainPassword + _hashOptions.StaticSalt);
            return result;
        }

        private byte[] GetDynamicSalt()
        {
            var result = new byte[_hashOptions.SaltSize];
            _rng.GetNonZeroBytes(result);
            return result;
        }

        private byte[] Hash(byte[] saltedPassword, byte[] dynamicSalt)
        {
            return SCrypt.GetEffectivePbkdf2Salt(saltedPassword, 
                dynamicSalt, 
                _hashOptions.Cost, 
                _hashOptions.BlockSize, 
                _hashOptions.Parallel, 
                _hashOptions.MaxThreads);
        }

        public IPassword Hash(string plainPassword)
        {
            if (String.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException(nameof(plainPassword));

            var dynamicSalt = GetDynamicSalt();
            var result = new Password(dynamicSalt, Hash(SaltPassword(plainPassword), dynamicSalt));
            return result;
        }

        public bool Compare(IPassword hashedPassword, string plainPassword)
        {
            if (hashedPassword.Hash == null || !hashedPassword.Hash.Any() ||
                hashedPassword.Salt == null || !hashedPassword.Salt.Any())
                throw new ArgumentException(nameof(hashedPassword));

            var passwordHash = Hash(SaltPassword(plainPassword), hashedPassword.Salt);
            var result = Enumerable.SequenceEqual(passwordHash, hashedPassword.Hash);
            return result;
        }
    }
}

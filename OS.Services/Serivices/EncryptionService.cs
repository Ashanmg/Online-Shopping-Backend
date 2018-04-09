using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OS.Services.Serivices
{
    public class EncryptionService : IEncryptionService
    {
        public string CreateSalt(int size)
        {
            var data = new Byte[size];
            var cryptoServiceProvider = System.Security.Cryptography.RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var salteedPassword = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(salteedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordBytes));
            }
        }
    }
}

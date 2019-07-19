using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BaseAPI.Core
{
    public static class TokenHash
    {
        private const int HASH_BYTE_SIZE = 24;
        private const int SALT_BYTE_SIZE = 24;
        private const int PBKDF2_ITERATIONS = 1000;

        public static string CreateHash(string token)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(token, SALT_BYTE_SIZE, PBKDF2_ITERATIONS);
            return Convert.ToBase64String(pbkdf2.GetBytes(HASH_BYTE_SIZE));
        }
    }

}

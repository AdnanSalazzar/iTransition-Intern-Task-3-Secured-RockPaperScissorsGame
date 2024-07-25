using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    public static class CryptoManager
    {
        public static byte[] GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32]; 
                rng.GetBytes(key);
                return key;
            }
        }

        public static string ComputeHMAC(string message, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}

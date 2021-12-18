using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RedPillCorp.WebShop.Domain.Cryptography
{

    public class Crypto
    {
        public const int SALT_LENGTH = 8;
        
        public static string GetHashWithSalt(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            List<Byte> combinedBytes = new List<Byte>();
            
            combinedBytes.AddRange(passwordBytes);
            combinedBytes.AddRange(saltBytes);
            Byte[] hash = SHA256.Create().ComputeHash(combinedBytes.ToArray());

            return Convert.ToBase64String(hash);
        }

        public static ValueTuple<string, string> MakeHashAndSalt(string password)
        {
            byte[] saltBytes = GenerateRandomCryptographicBytes();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            List<Byte> combinedBytes = new List<Byte>();
            
            combinedBytes.AddRange(passwordBytes);
            combinedBytes.AddRange(saltBytes);
            Byte[] hash = SHA256.Create().ComputeHash(combinedBytes.ToArray());

            return (Convert.ToBase64String(hash), Convert.ToBase64String(saltBytes));
        }

        // HELPER METHOD
        private static byte[] GenerateRandomCryptographicBytes()
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[SALT_LENGTH];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace WriteDownOnlineApi.Domain.Dtos
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 10000, HashAlgorithmName.SHA256).GetBytes(32);

            byte[] hashSaltBytes = new byte[48];
            Buffer.BlockCopy(salt, 0, hashSaltBytes, 0, 16);
            Buffer.BlockCopy(hashBytes, 0, hashSaltBytes, 16, 32);

            return Convert.ToBase64String(hashSaltBytes);
        }

        public static bool Verify(string password, string hash)
        {
            byte[] hashSaltBytes = Convert.FromBase64String(hash);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashSaltBytes, 0, salt, 0, 16);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 10000, HashAlgorithmName.SHA256).GetBytes(32);

            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i] != hashSaltBytes[i + 16])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

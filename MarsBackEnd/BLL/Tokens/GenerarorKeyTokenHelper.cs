using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;


namespace BLL.Tokens
{
    public class GenerarorKeyTokenHelper
    {
        public string GenerateRandomSymmetricKey()
        {
            byte[] keyBytes = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }
    }
}

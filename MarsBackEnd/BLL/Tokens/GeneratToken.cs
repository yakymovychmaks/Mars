using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Tokens
{
    public class GeneratToken
    {
        private readonly string _SecretKey;
        public GeneratToken(string SecretKey)
        {
            _SecretKey = SecretKey;
        }
        public string GenerateToken(List<Claim> claims, DateTime expires)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_SecretKey));
            var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                claims:  claims,
                expires:  expires,
                signingCredentials:  creads);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_SecretKey));

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                return principal;
            }
            catch
            {
                // Якщо токен не валідний, повертаємо null
                return null;
            }
        }
    }
}

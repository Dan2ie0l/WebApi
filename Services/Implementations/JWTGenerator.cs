using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestApi.Domain.Core;
using RestApi.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RestApi.Services.Implementations
{
    public class JWTGenerator : IJWTGenerator
    {
        private readonly IConfiguration configuration;

        public JWTGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateTokenForUser(string userId, string userName)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this.configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}

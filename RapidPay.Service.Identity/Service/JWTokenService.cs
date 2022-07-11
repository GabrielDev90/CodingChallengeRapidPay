using Microsoft.IdentityModel.Tokens;
using RapidPay.Service.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RapidPay.Service.Identity.Service
{
    public class JWTokenService : IJWTokenService
    {
        public string key { get; }
        public string issuer { get; }

        public JWTokenService(IConfiguration configuration)
        {
            key = configuration["JWTService:key"];
            issuer = configuration["JWTService:issuer"];
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credenciais,
                Issuer = issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

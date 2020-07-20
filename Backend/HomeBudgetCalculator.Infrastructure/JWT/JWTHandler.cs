using HomeBudgetCalculator.Infrastructure.DTO;
using HomeBudgetCalculator.Infrastructure.JWT.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeBudgetCalculator.Infrastructure.JWT
{
    public class JWTHandler : IJWTHandler
    {
        public JwtDTO CreateToken(string login, string email)
        {
            var claim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(JwtRegisteredClaimNames.UniqueName, login),
                new Claim(ClaimTypes.Role, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var Credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projekt_zespolowy_!12345")),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken
                (
                issuer: "https://localhost:44395",
                claims: claim,
                notBefore: DateTime.Now,
                signingCredentials: Credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDTO
            {
                Token = token
            };
        }
    }
}

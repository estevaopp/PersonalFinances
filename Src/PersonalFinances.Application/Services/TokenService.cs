using System.Security.Claims;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace PersonalFinances.Application.Services
{
    public class TokenService : ITokenService
    {
        public Token GenerateToken(User user, string role,IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("PersonalFinancesApiSecurityKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim("userId", user.Id.ToString()),
                        new Claim("username", user.Username),
                        new Claim("email", user.Email),
                        new Claim(ClaimTypes.Role, role)
                    }
                ),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            Token token = new Token(tokenHandler.WriteToken(securityToken));

            return token;
        }
    }
}
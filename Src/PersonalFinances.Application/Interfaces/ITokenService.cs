using Microsoft.Extensions.Configuration;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.Interfaces
{
    public interface ITokenService
    {
        public Token GenerateToken(User user, IConfiguration configuration);
    }
}
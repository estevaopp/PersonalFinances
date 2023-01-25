using PersonalFinances.Application.ViewModel.Request.User;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<Token> Login(LoginRequest login);

        Task Register(CreateUserRequest createUserRequest);
    }
}
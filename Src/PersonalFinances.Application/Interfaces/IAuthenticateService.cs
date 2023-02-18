using PersonalFinances.Application.ViewModel.Request.User;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<Token> Login(LoginRequest login);

        Task<UserResponse> Register(CreateUserRequest createUserRequest);
    }
}
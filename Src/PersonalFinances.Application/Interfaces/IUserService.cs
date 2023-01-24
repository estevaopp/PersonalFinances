using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Request.User;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(LoginRequest login);

        Task<UserResponse> GetUserById(int id);

        Task<UserResponse> GetMyUser();

        Task<List<UserResponse>> GetAllUsers();

        Task<UserResponse> Create(CreateUserRequest login);

        Task<UserResponse> HardResetPassword();
    }
}
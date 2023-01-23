using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Request.User;

namespace PersonalFinances.Application.Interfaces
{
    public interface IUserService
    {
        Task Login(LoginRequest login);

        Task Create(LoginRequest login);

        Task HardResetPassword(LoginRequest login);
    }
}
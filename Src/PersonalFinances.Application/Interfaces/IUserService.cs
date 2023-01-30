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
        Task<UserResponse> GetById(int id);

        Task<List<UserResponse>> GetAll();
    }
}
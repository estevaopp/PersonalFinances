using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Request.UserRole;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRoleResponse> GetById(int id);

        Task<List<UserRoleResponse>> GetAll();

        Task Create(CreateUserRoleRequest createUserRoleRequest);

        Task Update(UpdateUserRoleRequest updateUserRoleRequest, int id);

        Task Delete(int id);
    }
}
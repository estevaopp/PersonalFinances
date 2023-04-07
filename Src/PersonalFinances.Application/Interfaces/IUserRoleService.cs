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

        Task<UserRoleResponse> Create(CreateUserRoleRequest createUserRoleRequest);

        Task<UserRoleResponse> Update(UpdateUserRoleRequest updateUserRoleRequest, int id);

        Task<UserRoleResponse> Delete(int id);
    }
}
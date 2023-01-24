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
        Task<UserRoleResponse> GetUserRoleById();

        Task<List<UserRoleResponse>> GetAllUserRoles();

        Task<UserRoleResponse> Create(CreateUserRoleRequest login);

        Task<UserRoleResponse> Update(UpdateUserRoleRequest login);
    }
}
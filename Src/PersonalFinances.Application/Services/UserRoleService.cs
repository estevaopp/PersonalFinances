using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.UserRole;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Interfaces;

namespace PersonalFinances.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private IAsyncRepository<UserRole> _userRoleRepository;
        private IMapper _mapper;

        public UserRoleService(IMapper mapper, IAsyncRepository<UserRole> userRoleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<List<UserRoleResponse>> GetAllUserRoles()
        {
            List<UserRole> userRoles = (List<UserRole>) await _userRoleRepository.GetAllAsNoTrackingAsync();
            List<UserRoleResponse> userRoleResponses = _mapper.Map<List<UserRoleResponse>>(userRoles); 

            return userRoleResponses;
        }

        public async Task<UserRoleResponse> GetUserRoleById(int id)
        {
            UserRole userRole = (UserRole) await _userRoleRepository.GetByIdAsNoTrackingAsync(id);
            UserRoleResponse userRoleResponse = _mapper.Map<UserRoleResponse>(userRole); 

            return userRoleResponse;
        }

        public async Task Create(CreateUserRoleRequest createUserRoleRequest)
        {
            UserRole userRole = new UserRole(createUserRoleRequest.Name, createUserRoleRequest.Description);
            await _userRoleRepository.AddAsync(userRole);
        }

        public async Task Update(UpdateUserRoleRequest updateUserRoleRequest, int id)
        {
            UserRole userRole = await _userRoleRepository.GetByIdAsync(id);

            if (userRole == null)
                throw new BusinessException("Invalid Id");
            
            userRole.Update(updateUserRoleRequest.Name, updateUserRoleRequest.Description);

            await _userRoleRepository.UpdateAsync(userRole);
        }

        public async Task Delete(int id)
        {
            UserRole userRole = await _userRoleRepository.GetByIdAsync(id);

            if (userRole == null)
                throw new BusinessException("Invalid Id");

            await _userRoleRepository.DeleteAsync(userRole);
        }
    }
}
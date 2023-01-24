using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.User;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;

namespace PersonalFinances.Application.Services
{
    public class UserService : IUserService
    {
        private IAsyncRepository<User> _userRepository;
        private IMapper _mapper;

        public UserService(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task Create(CreateUserRequest createUserRequest)
        {
            User user = new User(createUserRequest.Username, createUserRequest.Email, createUserRequest.Password, 1);
            await _userRepository.AddAsync(user);
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            List<User> users = (List<User>) await _userRepository.GetAllAsync();
            List<UserResponse> userResponses = _mapper.Map<List<UserResponse>>(users); 

            return userResponses;
        }

        public async Task<UserResponse> GetMyUser()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            User user = (User) await _userRepository.GetByIdAsNoTrackingAsync(id);
            UserResponse userResponse = _mapper.Map<UserResponse>(user); 

            return userResponse;
        }

        public async Task HardResetPassword()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(LoginRequest login)
        {
            throw new NotImplementedException();
        }
    }
}
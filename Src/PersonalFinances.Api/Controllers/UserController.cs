using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Application.ViewModel.Response.CommandResponse;

namespace PersonalFinances.Api.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponse>> GetById(int id)
        {
            var userResponse = await _userService.GetById(id);

            if(userResponse == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = userResponse
                }
            );
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponse>> Get()
        {
            var userResponse = await _userService.GetAll();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = userResponse
                }
            );
        }

        [HttpGet]
        [Route("me")]
        public async Task<ActionResult<UserResponse>> GetMyUser()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var userResponse = await _userService.GetById(userId);

            if(userResponse == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = userResponse
                }
            );
        }
    }
}
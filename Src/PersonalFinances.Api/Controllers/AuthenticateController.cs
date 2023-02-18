using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.User;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Application.ViewModel.Response.CommandResponse;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Api.Controllers
{
    [ApiController]
    [Route("api/Account")]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Token>> Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(LoginRequest), ErroEnum.ResourceBadRequest));

            var token = await _authenticateService.Login(login);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = token
                }
            );
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Token>> Register(CreateUserRequest createUser)
        {
            if (createUser == null)
                throw new ArgumentNullException(nameof(createUser));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(CreateUserRequest), ErroEnum.ResourceBadRequest));

            UserResponse user = await _authenticateService.Register(createUser);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = user
                }
            );
        }
    }
}
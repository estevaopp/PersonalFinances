using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.UserRole;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Application.ViewModel.Response.CommandResponse;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<UserRoleResponse>> GetById(int id)
        {
            var userRoleResponse = await _userRoleService.GetById(id);

            if(userRoleResponse == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = userRoleResponse
                }
            );
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<UserRoleResponse>> Get()
        {
            var userRoleResponse = await _userRoleService.GetAll();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = userRoleResponse
                }
            );
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(CreateUserRoleRequest createUserRoleRequest)
        {
            if (createUserRoleRequest == null)
                throw new ArgumentNullException(nameof(createUserRoleRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(CreateUserRoleRequest), ErroEnum.ResourceBadRequest));

            await _userRoleService.Create(createUserRoleRequest);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(UpdateUserRoleRequest updateUserRoleRequest, int id)
        {
            if (updateUserRoleRequest == null)
                throw new ArgumentNullException(nameof(updateUserRoleRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(UpdateUserRoleRequest), ErroEnum.ResourceBadRequest));

            await _userRoleService.Update(updateUserRoleRequest, id);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userRoleService.Delete(id);

            return Ok();
        }
    }
}
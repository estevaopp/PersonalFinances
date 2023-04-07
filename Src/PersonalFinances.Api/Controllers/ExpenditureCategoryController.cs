using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Application.ViewModel.Response.CommandResponse;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Api.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenditureCategoryController : ControllerBase
    {
        private readonly IExpenditureCategoryService _expenditureCategoryService;

        public ExpenditureCategoryController(IExpenditureCategoryService expenditureCategoryService)
        {
            _expenditureCategoryService = expenditureCategoryService;
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ExpenditureCategoryResponse>> GetById(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.GetByIdAndUserId(id, userId);

            if(expenditureCategoryResponse == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ExpenditureCategoryResponse>> Get()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponses = await _expenditureCategoryService.GetByUserId(userId);

            if(expenditureCategoryResponses == null)
                return NotFound();

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponses
                }
            );
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(CreateExpenditureCategoryRequest createExpenditureCategoryRequest)
        {
            if (createExpenditureCategoryRequest == null)
                throw new ArgumentNullException(nameof(createExpenditureCategoryRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(CreateExpenditureCategoryRequest), ErroEnum.ResourceBadRequest));

            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.Create(createExpenditureCategoryRequest, userId);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(UpdateExpenditureCategoryRequest updateExpenditureCategoryRequest, int id)
        {
            if (updateExpenditureCategoryRequest == null)
                throw new ArgumentNullException(nameof(updateExpenditureCategoryRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(UpdateExpenditureCategoryRequest), ErroEnum.ResourceBadRequest));

            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.Update(updateExpenditureCategoryRequest, id, userId);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ExpenditureCategoryResponse>> Delete(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureCategoryResponse = await _expenditureCategoryService.Delete(id, userId);

            return Ok
            (
                new Response
                {
                    Success = true,
                    Data = expenditureCategoryResponse
                }
            );
        }
    }
}
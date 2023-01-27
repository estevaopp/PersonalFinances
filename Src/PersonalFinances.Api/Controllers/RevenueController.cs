using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.Revenue;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Enums;
using PersonalFinances.Domain.Exceptions;

namespace PersonalFinances.Api.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;

        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<RevenueResponse>> GetById(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var revenueResponse = await _revenueService.GetRevenueById(id, userId);

            if(revenueResponse == null)
                return NotFound();

            return Ok(revenueResponse);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<RevenueResponse>> Get()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var revenueResponses = await _revenueService.GetAllRevenues(userId);

            if(revenueResponses == null)
                return NotFound();

            return Ok(revenueResponses);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(CreateRevenueRequest createRevenueRequest)
        {
            if (createRevenueRequest == null)
                throw new ArgumentNullException(nameof(createRevenueRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(CreateRevenueRequest), ErroEnum.ResourceBadRequest));

            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            await _revenueService.Create(createRevenueRequest, userId);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(UpdateRevenueRequest updateRevenueRequest, int id)
        {
            if (updateRevenueRequest == null)
                throw new ArgumentNullException(nameof(updateRevenueRequest));
            
            if (!ModelState.IsValid)
                return BadRequest(new BusinessException("Invalid Request", nameof(UpdateRevenueRequest), ErroEnum.ResourceBadRequest));

            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            await _revenueService.Update(updateRevenueRequest, id, userId);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<RevenueResponse>> Delete(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            await _revenueService.Delete(id, userId);

            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.Expenditure;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;

        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ExpenditureResponse>> GetById(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureResponse = await _expenditureService.GetExpenditureById(id, userId);

            if(expenditureResponse == null)
                return NotFound();

            return Ok(expenditureResponse);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ExpenditureResponse>> Get()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var expenditureResponses = await _expenditureService.GetAllExpenditures(userId);

            if(expenditureResponses == null)
                return NotFound();

            return Ok(expenditureResponses);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(CreateExpenditureRequest createExpenditureRequest)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            await _expenditureService.Create(createExpenditureRequest, userId);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(UpdateExpenditureRequest updateExpenditureRequest, int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            await _expenditureService.Update(updateExpenditureRequest, id, userId);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ExpenditureResponse>> Delete(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            await _expenditureService.Delete(id, userId);

            return Ok();
        }
    }
}
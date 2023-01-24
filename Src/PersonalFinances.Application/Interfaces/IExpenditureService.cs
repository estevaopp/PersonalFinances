using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Request.Expenditure;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Application.Interfaces
{
    public interface IExpenditureService
    {
        Task<ExpenditureResponse> GetExpenditureById();

        Task<List<ExpenditureResponse>> GetAllExpenditures();

        Task<ExpenditureResponse> Create(CreateExpenditureRequest createExpenditureRequest);

        Task<ExpenditureResponse> Update(UpdateExpenditureRequest updateExpenditureRequest);

        Task Delete(int id);
    }
}
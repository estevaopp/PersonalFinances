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
        Task<ExpenditureResponse> GetExpenditureById(int id);

        Task<List<ExpenditureResponse>> GetAllExpenditures();

        Task Create(CreateExpenditureRequest createExpenditureRequest);

        Task Update(UpdateExpenditureRequest updateExpenditureRequest);

        Task Delete(int id);
    }
}
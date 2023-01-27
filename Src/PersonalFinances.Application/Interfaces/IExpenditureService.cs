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
        Task<ExpenditureResponse> GetExpenditureById(int id, int userId);

        Task<List<ExpenditureResponse>> GetAllExpenditures(int userId);

        Task Create(CreateExpenditureRequest createExpenditureRequest, int userId);

        Task Update(UpdateExpenditureRequest updateExpenditureRequest, int id, int userId);

        Task Delete(int id, int userId);
    }
}
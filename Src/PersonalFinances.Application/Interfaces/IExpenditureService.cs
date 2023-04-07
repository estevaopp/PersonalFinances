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
        Task<ExpenditureResponse> GetByIdAndUserId(int id, int userId);

        Task<List<ExpenditureResponse>> GetByUserId(int userId);

        Task<ExpenditureResponse> Create(CreateExpenditureRequest createExpenditureRequest, int userId);

        Task<ExpenditureResponse> Update(UpdateExpenditureRequest updateExpenditureRequest, int id, int userId);

        Task<ExpenditureResponse> Delete(int id, int userId);
    }
}
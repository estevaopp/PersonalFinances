using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Application.Interfaces
{
    public interface IExpenditureCategoryService
    {
        Task<ExpenditureCategoryResponse> GetByIdAndUserId(int id, int userId);

        Task<List<ExpenditureCategoryResponse>> GetByUserId(int userId);

        Task Create(CreateExpenditureCategoryRequest createExpenditureCategoryRequest, int userId);

        Task Update(UpdateExpenditureCategoryRequest updateExpenditureCategoryRequest, int id,int userId);

        Task Delete(int id, int userId);
    }
}
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

        Task<ExpenditureCategoryResponse> Create(CreateExpenditureCategoryRequest createExpenditureCategoryRequest, int userId);

        Task<ExpenditureCategoryResponse> Update(UpdateExpenditureCategoryRequest updateExpenditureCategoryRequest, int id,int userId);

        Task<ExpenditureCategoryResponse> Delete(int id, int userId);
    }
}
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
        Task<ExpenditureCategoryResponse> GetExpenditureCategoryById();

        Task<List<ExpenditureCategoryResponse>> GetAllExpenditureCategories();

        Task<ExpenditureCategoryResponse> Create(CreateExpenditureCategoryRequest createExpenditureCategoryRequest);

        Task<ExpenditureCategoryResponse> Update(UpdateExpenditureCategoryRequest updateExpenditureCategoryRequest);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Application.ViewModel.Request.RevenueCategory;

namespace PersonalFinances.Application.Interfaces
{
    public interface IRevenueCategoryService
    {
        Task<RevenueCategoryResponse> GetRevenueCategoryById(int id);

        Task<List<RevenueCategoryResponse>> GetAllRevenueCategories();

        Task Create(CreateRevenueCategoryRequest createRevenueCategoryRequest);

        Task Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest);

        Task Delete(int id);
    }
}
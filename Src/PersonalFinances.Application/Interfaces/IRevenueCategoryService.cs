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
        Task<RevenueCategoryResponse> GetRevenueCategoryById(int id, int userId);

        Task<List<RevenueCategoryResponse>> GetAllRevenueCategories(int userId);

        Task Create(CreateRevenueCategoryRequest createRevenueCategoryRequest, int userId);

        Task Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest, int id, int userId);

        Task Delete(int id, int userId);
    }
}
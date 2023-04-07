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
        Task<RevenueCategoryResponse> GetByIdAndUserId(int id, int userId);

        Task<List<RevenueCategoryResponse>> GetByUserId(int userId);

        Task<RevenueCategoryResponse> Create(CreateRevenueCategoryRequest createRevenueCategoryRequest, int userId);

        Task<RevenueCategoryResponse> Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest, int id, int userId);

        Task<RevenueCategoryResponse> Delete(int id, int userId);
    }
}
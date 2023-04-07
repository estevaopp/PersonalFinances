using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Application.ViewModel.Request.Revenue;
using PersonalFinances.Application.ViewModel.Response;

namespace PersonalFinances.Application.Interfaces
{
    public interface IRevenueService
    {
        Task<RevenueResponse> GetByIdAndUserId(int id, int userId);

        Task<List<RevenueResponse>> GetByUserId(int userId);

        Task<RevenueResponse> Create(CreateRevenueRequest createRevenueRequest, int userId);

        Task<RevenueResponse> Update(UpdateRevenueRequest updateRevenueRequest, int id, int userId);

        Task<RevenueResponse> Delete(int id, int userId);
    }
}
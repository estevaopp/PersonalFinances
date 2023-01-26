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
        Task<RevenueResponse> GetRevenueById(int id, int userId);

        Task<List<RevenueResponse>> GetAllRevenues(int userId);

        Task Create(CreateRevenueRequest createRevenueRequest, int userId);

        Task Update(UpdateRevenueRequest updateRevenueRequest, int id, int userId);

        Task Delete(int id, int userId);
    }
}
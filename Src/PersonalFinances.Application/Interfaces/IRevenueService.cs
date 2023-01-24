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
        Task<RevenueResponse> GetRevenueById();

        Task<List<RevenueResponse>> GetAllRevenues();

        Task<RevenueResponse> Create(CreateRevenueRequest createRevenueRequest);

        Task<RevenueResponse> Update(UpdateRevenueRequest updateRevenueRequest);

        Task Delete(int id);
    }
}
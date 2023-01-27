using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.Revenue;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Interfaces;

namespace PersonalFinances.Application.Services
{
    public class RevenueService : IRevenueService
    {
        private IAsyncRepository<Revenue> _revenueRepository;
        private IMapper _mapper;

        public RevenueService(IMapper mapper, IAsyncRepository<Revenue> revenueRepository)
        {
            _mapper = mapper;
            _revenueRepository = revenueRepository;
        }


        public async Task Create(CreateRevenueRequest createRevenueRequest, int userId)
        {
            Revenue revenue = new Revenue(createRevenueRequest.Name, createRevenueRequest.RevenueCategoryId, createRevenueRequest.Date,
                                          createRevenueRequest.Value, createRevenueRequest.Description, userId);

            await _revenueRepository.AddAsync(revenue);
        }

        public async Task Delete(int id, int userId)
        {
            Revenue revenue = (Revenue) (await _revenueRepository.FindByAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();

            if (revenue == null)
                throw new BusinessException("Invalid Id");

            await _revenueRepository.DeleteAsync(revenue);
        }

        public async Task<List<RevenueResponse>> GetAllRevenues(int userId)
        {
            List<Revenue> revenues = (List<Revenue>) await _revenueRepository.FindByAsNoTrackingAsync(x => x.UserId == userId);
            List<RevenueResponse> revenueResponses = _mapper.Map<List<RevenueResponse>>(revenues); 

            return revenueResponses;
        }

        public async Task<RevenueResponse> GetRevenueById(int id, int userId)
        {
            Revenue revenue = (Revenue) (await _revenueRepository.FindByAsNoTrackingAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();
            RevenueResponse revenueResponse = _mapper.Map<RevenueResponse>(revenue); 

            return revenueResponse;
        }

        public async Task Update(UpdateRevenueRequest updateRevenueRequest, int id, int userId)
        {
            Revenue revenue = (Revenue) (await _revenueRepository.FindByAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();

            if (revenue == null)
                throw new BusinessException("Invalid Id");

            revenue.Update(updateRevenueRequest.Name, updateRevenueRequest.RevenueCategoryId, updateRevenueRequest.Date,
                           updateRevenueRequest.Value, updateRevenueRequest.Description);

            await _revenueRepository.UpdateAsync(revenue);
        }
    }
}
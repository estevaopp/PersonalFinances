using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.RevenueCategory;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Interfaces;

namespace PersonalFinances.Application.Services
{
    public class RevenueCategoryService : IRevenueCategoryService
    {
        private IAsyncRepository<RevenueCategory> _revenueCategoryRepository;
        private IMapper _mapper;

        public RevenueCategoryService(IMapper mapper, IAsyncRepository<RevenueCategory> revenueCategoryRepository)
        {
            _mapper = mapper;
            _revenueCategoryRepository = revenueCategoryRepository;
        }

        public async Task Create(CreateRevenueCategoryRequest createRevenueCategoryRequest, int userId)
        {
            RevenueCategory revenueCategory = new RevenueCategory(createRevenueCategoryRequest.Name, createRevenueCategoryRequest.Description, userId);
            await _revenueCategoryRepository.AddAsync(revenueCategory);
        }

        public async Task Delete(int id, int userId)
        {
            RevenueCategory revenueCategory = (await _revenueCategoryRepository.FindByAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();

            if (revenueCategory == null)
                throw new BusinessException("Invalid Id");

            await _revenueCategoryRepository.DeleteAsync(revenueCategory);
        }

        public async Task<List<RevenueCategoryResponse>> GetAllRevenueCategories(int userId)
        {
            List<RevenueCategory> revenueCategories = (List<RevenueCategory>) await _revenueCategoryRepository.FindByAsNoTrackingAsync(x => x.UserId == userId);
            List<RevenueCategoryResponse> revenueCategoryResponses = _mapper.Map<List<RevenueCategoryResponse>>(revenueCategories); 

            return revenueCategoryResponses;
        }

        public async Task<RevenueCategoryResponse> GetRevenueCategoryById(int id, int userId)
        {
            RevenueCategory revenueCategory = (RevenueCategory) (await _revenueCategoryRepository.FindByAsNoTrackingAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();
            RevenueCategoryResponse revenueCategoryResponse = _mapper.Map<RevenueCategoryResponse>(revenueCategory); 

            return revenueCategoryResponse;
        }

        public async Task Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest, int id, int userId)
        {
            RevenueCategory revenueCategory = (await _revenueCategoryRepository.FindByAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();

            if (revenueCategory == null)
                throw new BusinessException("Invalid Id");

            revenueCategory.Update(updateRevenueCategoryRequest.Name, updateRevenueCategoryRequest.Description);

            await _revenueCategoryRepository.UpdateAsync(revenueCategory);
        }
    }
}
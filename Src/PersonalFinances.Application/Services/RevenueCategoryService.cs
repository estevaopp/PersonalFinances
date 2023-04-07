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
        private IRevenueCategoryRepository _revenueCategoryRepository;
        private IMapper _mapper;

        public RevenueCategoryService(IMapper mapper, IRevenueCategoryRepository revenueCategoryRepository)
        {
            _mapper = mapper;
            _revenueCategoryRepository = revenueCategoryRepository;
        }

        public async Task<RevenueCategoryResponse> Create(CreateRevenueCategoryRequest createRevenueCategoryRequest, int userId)
        {
            RevenueCategory revenueCategory = new RevenueCategory(createRevenueCategoryRequest.Name, createRevenueCategoryRequest.Description, userId);
            await _revenueCategoryRepository.AddAsync(revenueCategory);
            
            RevenueCategoryResponse revenueCategoryResponse = _mapper.Map<RevenueCategoryResponse>(revenueCategory); 

            return revenueCategoryResponse;
        }

        public async Task<RevenueCategoryResponse> Delete(int id, int userId)
        {
            RevenueCategory revenueCategory = await _revenueCategoryRepository.GetByIdAndUserIdAsync(id, userId);

            if (revenueCategory == null)
                throw new BusinessException("Invalid Id");

            await _revenueCategoryRepository.DeleteAsync(revenueCategory);
            
            RevenueCategoryResponse revenueCategoryResponse = _mapper.Map<RevenueCategoryResponse>(revenueCategory); 

            return revenueCategoryResponse;
        }

        public async Task<List<RevenueCategoryResponse>> GetByUserId(int userId)
        {
            List<RevenueCategory> revenueCategories = (List<RevenueCategory>) await _revenueCategoryRepository.GetByUserIdAsNoTrackingAsync(userId);
            List<RevenueCategoryResponse> revenueCategoryResponses = _mapper.Map<List<RevenueCategoryResponse>>(revenueCategories); 

            return revenueCategoryResponses;
        }

        public async Task<RevenueCategoryResponse> GetByIdAndUserId(int id, int userId)
        {
            RevenueCategory revenueCategory = (RevenueCategory) await _revenueCategoryRepository.GetByIdAndUserIdAsNoTrackingAsync(id, userId);
            RevenueCategoryResponse revenueCategoryResponse = _mapper.Map<RevenueCategoryResponse>(revenueCategory); 

            return revenueCategoryResponse;
        }

        public async Task<RevenueCategoryResponse> Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest, int id, int userId)
        {
            RevenueCategory revenueCategory = await _revenueCategoryRepository.GetByIdAndUserIdAsync(id, userId);

            if (revenueCategory == null)
                throw new BusinessException("Invalid Id");

            revenueCategory.Update(updateRevenueCategoryRequest.Name, updateRevenueCategoryRequest.Description);

            await _revenueCategoryRepository.UpdateAsync(revenueCategory);
            
            RevenueCategoryResponse revenueCategoryResponse = _mapper.Map<RevenueCategoryResponse>(revenueCategory); 

            return revenueCategoryResponse;
        }
    }
}
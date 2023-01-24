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


        public async Task Create(CreateRevenueCategoryRequest createRevenueCategoryRequest)
        {
            RevenueCategory revenueCategory = new RevenueCategory(createRevenueCategoryRequest.Name, createRevenueCategoryRequest.Description);
            await _revenueCategoryRepository.AddAsync(revenueCategory);
        }

        public async Task Delete(int id)
        {
            RevenueCategory revenueCategory = await _revenueCategoryRepository.GetByIdAsync(id);

            if (revenueCategory == null)
                throw new BusinessException("Invalid Id");

            await _revenueCategoryRepository.DeleteAsync(revenueCategory);
        }

        public async Task<List<RevenueCategoryResponse>> GetAllRevenueCategories()
        {
            List<RevenueCategory> revenueCategories = (List<RevenueCategory>) await _revenueCategoryRepository.GetAllAsync();
            List<RevenueCategoryResponse> revenueCategoryResponses = _mapper.Map<List<RevenueCategoryResponse>>(revenueCategories); 

            return revenueCategoryResponses;
        }

        public async Task<RevenueCategoryResponse> GetRevenueCategoryById(int id)
        {
            RevenueCategory revenueCategory = (RevenueCategory) await _revenueCategoryRepository.GetByIdAsNoTrackingAsync(id);
            RevenueCategoryResponse revenueCategoryResponse = _mapper.Map<RevenueCategoryResponse>(revenueCategory); 

            return revenueCategoryResponse;
        }

        public async Task Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest)
        {
            RevenueCategory revenueCategory = await _revenueCategoryRepository.GetByIdAsync(updateRevenueCategoryRequest.Id);

            if (revenueCategory == null)
                throw new BusinessException("Invalid Id");

            revenueCategory.Update(updateRevenueCategoryRequest.Name, updateRevenueCategoryRequest.Description);

            await _revenueCategoryRepository.UpdateAsync(revenueCategory);
        }
    }
}
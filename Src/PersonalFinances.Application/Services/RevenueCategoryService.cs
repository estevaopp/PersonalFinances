using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.RevenueCategory;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
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
            throw new NotImplementedException();
        }

        public async Task<List<RevenueCategoryResponse>> GetAllRevenueCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<RevenueCategoryResponse> GetRevenueCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateRevenueCategoryRequest updateRevenueCategoryRequest)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Interfaces;

namespace PersonalFinances.Application.Services
{
    public class ExpenditureCategoryService : IExpenditureCategoryService
    {
        private IAsyncRepository<ExpenditureCategory> _expenditureCategoryRepository;
        private IMapper _mapper;

        public ExpenditureCategoryService(IMapper mapper, IAsyncRepository<ExpenditureCategory> expenditureCategoryRepository)
        {
            _mapper = mapper;
            _expenditureCategoryRepository = expenditureCategoryRepository;
        }


        public async Task Create(CreateExpenditureCategoryRequest createExpenditureCategoryRequest)
        {
            ExpenditureCategory expenditureCategory = new ExpenditureCategory(createExpenditureCategoryRequest.Name, createExpenditureCategoryRequest.Description);
            await _expenditureCategoryRepository.AddAsync(expenditureCategory);
        }

        public async Task Delete(int id)
        {
            ExpenditureCategory expenditureCategory = await _expenditureCategoryRepository.GetByIdAsync(id);

            if (expenditureCategory == null)
                throw new BusinessException("Invalid Id");

            await _expenditureCategoryRepository.DeleteAsync(expenditureCategory);
        }

        public async Task<List<ExpenditureCategoryResponse>> GetAllExpenditureCategories()
        {
            List<ExpenditureCategory> expenditureCategories = (List<ExpenditureCategory>) await _expenditureCategoryRepository.GetAllAsync();
            List<ExpenditureCategoryResponse> expenditureCategoryResponses = _mapper.Map<List<ExpenditureCategoryResponse>>(expenditureCategories); 

            return expenditureCategoryResponses;
        }

        public async Task<ExpenditureCategoryResponse> GetExpenditureCategoryById(int id)
        {
            ExpenditureCategory expenditureCategory = (ExpenditureCategory) await _expenditureCategoryRepository.GetByIdAsNoTrackingAsync(id);
            ExpenditureCategoryResponse expenditureCategoryResponse = _mapper.Map<ExpenditureCategoryResponse>(expenditureCategory); 

            return expenditureCategoryResponse;
        }

        public async Task Update(UpdateExpenditureCategoryRequest updateexpenditureCategoryRequest)
        {
            ExpenditureCategory expenditureCategory = await _expenditureCategoryRepository.GetByIdAsync(updateexpenditureCategoryRequest.Id);

            if (expenditureCategory == null)
                throw new BusinessException("Invalid Id");

            expenditureCategory.Update(updateexpenditureCategoryRequest.Name, updateexpenditureCategoryRequest.Description);

            await _expenditureCategoryRepository.UpdateAsync(expenditureCategory);
        }
    }
}
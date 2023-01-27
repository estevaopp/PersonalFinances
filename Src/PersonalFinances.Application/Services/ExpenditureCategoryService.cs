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


        public async Task Create(CreateExpenditureCategoryRequest createExpenditureCategoryRequest, int userId)
        {
            ExpenditureCategory expenditureCategory = new ExpenditureCategory(createExpenditureCategoryRequest.Name, createExpenditureCategoryRequest.Description, userId);
            await _expenditureCategoryRepository.AddAsync(expenditureCategory);
        }

        public async Task Delete(int id, int userId)
        {
            ExpenditureCategory expenditureCategory = (await _expenditureCategoryRepository.FindByAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();

            if (expenditureCategory == null)
                throw new BusinessException("Invalid Id");

            await _expenditureCategoryRepository.DeleteAsync(expenditureCategory);
        }

        public async Task<List<ExpenditureCategoryResponse>> GetAllExpenditureCategories(int userId)
        {
            List<ExpenditureCategory> expenditureCategories = (List<ExpenditureCategory>) await _expenditureCategoryRepository.FindByAsNoTrackingAsync(x => x.UserId == userId);
            List<ExpenditureCategoryResponse> expenditureCategoryResponses = _mapper.Map<List<ExpenditureCategoryResponse>>(expenditureCategories); 

            return expenditureCategoryResponses;
        }

        public async Task<ExpenditureCategoryResponse> GetExpenditureCategoryById(int id, int userId)
        {
            ExpenditureCategory expenditureCategory = (ExpenditureCategory) (await _expenditureCategoryRepository.FindByAsNoTrackingAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();
            ExpenditureCategoryResponse expenditureCategoryResponse = _mapper.Map<ExpenditureCategoryResponse>(expenditureCategory); 

            return expenditureCategoryResponse;
        }

        public async Task Update(UpdateExpenditureCategoryRequest updateExpenditureCategoryRequest, int id, int userId)
        {
            ExpenditureCategory expenditureCategory = (await _expenditureCategoryRepository.FindByAsync(x => x.UserId == userId && x.Id == id)).FirstOrDefault();

            if (expenditureCategory == null)
                throw new BusinessException("Invalid Id");

            expenditureCategory.Update(updateExpenditureCategoryRequest.Name, updateExpenditureCategoryRequest.Description);

            await _expenditureCategoryRepository.UpdateAsync(expenditureCategory);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.ViewModel.Request.Expenditure;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Exceptions;
using PersonalFinances.Domain.Interfaces;

namespace PersonalFinances.Application.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private IAsyncRepository<Expenditure> _expenditureRepository;
        private IMapper _mapper;

        public ExpenditureService(IMapper mapper, IAsyncRepository<Expenditure> expenditureRepository)
        {
            _mapper = mapper;
            _expenditureRepository = expenditureRepository;
        }


        public async Task Create(CreateExpenditureRequest createExpenditureRequest)
        {
            Expenditure expenditure = new Expenditure(createExpenditureRequest.Name, createExpenditureRequest.ExpenditureCategoryId, createExpenditureRequest.Date,
                                                      createExpenditureRequest.Value, createExpenditureRequest.Description, 1);
            await _expenditureRepository.AddAsync(expenditure);
        }

        public async Task Delete(int id)
        {
            Expenditure expenditure = await _expenditureRepository.GetByIdAsync(id);

            if (expenditure == null)
                throw new BusinessException("Invalid Id");

            await _expenditureRepository.DeleteAsync(expenditure);
        }

        public async Task<List<ExpenditureResponse>> GetAllExpenditures()
        {
            List<Expenditure> expenditures = (List<Expenditure>) await _expenditureRepository.GetAllAsync();
            List<ExpenditureResponse> expenditureResponses = _mapper.Map<List<ExpenditureResponse>>(expenditures); 

            return expenditureResponses;
        }

        public async Task<ExpenditureResponse> GetExpenditureById(int id)
        {
            Expenditure expenditure = (Expenditure) await _expenditureRepository.GetByIdAsNoTrackingAsync(id);
            ExpenditureResponse expenditureResponse = _mapper.Map<ExpenditureResponse>(expenditure); 

            return expenditureResponse;
        }

        public async Task Update(UpdateExpenditureRequest updateExpenditureRequest)
        {
            Expenditure expenditure = await _expenditureRepository.GetByIdAsync(updateExpenditureRequest.Id);

            if (expenditure == null)
                throw new BusinessException("Invalid Id");

            expenditure.Update(updateExpenditureRequest.Name, updateExpenditureRequest.ExpenditureCategoryId, updateExpenditureRequest.Date,
                               updateExpenditureRequest.Value, updateExpenditureRequest.Description);

            await _expenditureRepository.UpdateAsync(expenditure);
        }
    }
}
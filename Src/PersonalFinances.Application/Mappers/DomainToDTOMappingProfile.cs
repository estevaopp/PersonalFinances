using AutoMapper;
using PersonalFinances.Application.ViewModel.Response;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.Mappers;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<User, UserResponse>();

        CreateMap<UserRole, UserRoleResponse>();

        CreateMap<RevenueCategory, RevenueCategoryResponse>();

        CreateMap<ExpenditureCategory, ExpenditureCategoryResponse>();

        CreateMap<Revenue, RevenueResponse>();

        CreateMap<Expenditure, ExpenditureResponse>();
    }
}
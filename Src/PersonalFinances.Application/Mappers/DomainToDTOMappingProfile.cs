using AutoMapper;
using PersonalFinances.Application.ViewModel.Request.Expenditure;
using PersonalFinances.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinances.Application.ViewModel.Request.Revenue;
using PersonalFinances.Application.ViewModel.Request.RevenueCategory;
using PersonalFinances.Application.ViewModel.Request.User;
using PersonalFinances.Application.ViewModel.Request.UserRole;
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
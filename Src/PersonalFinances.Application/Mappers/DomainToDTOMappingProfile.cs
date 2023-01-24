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
        CreateMap<CreateUserRequest, User>();

        CreateMap<UserRole, UserRoleResponse>();
        CreateMap<CreateUserRoleRequest, UserRole>();
        CreateMap<UpdateUserRoleRequest, UserRole>();

        CreateMap<RevenueCategory, RevenueCategoryResponse>();
        CreateMap<CreateRevenueCategoryRequest, RevenueCategory>();
        CreateMap<UpdateRevenueCategoryRequest, RevenueCategory>();

        CreateMap<ExpenditureCategory, ExpenditureCategoryResponse>();
        CreateMap<CreateExpenditureCategoryRequest, ExpenditureCategory>();
        CreateMap<UpdateExpenditureCategoryRequest, ExpenditureCategory>();

        CreateMap<Revenue, RevenueResponse>();
        CreateMap<CreateRevenueRequest, Revenue>();
        CreateMap<CreateRevenueRequest, Revenue>();

        CreateMap<Expenditure, ExpenditureResponse>();
        CreateMap<CreateExpenditureRequest, Expenditure>();
        CreateMap<UpdateExpenditureRequest, Expenditure>();
    }
}
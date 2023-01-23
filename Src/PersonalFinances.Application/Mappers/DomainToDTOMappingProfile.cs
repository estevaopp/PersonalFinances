using AutoMapper;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Application.Mappers;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<UserRole, UserRoleDTO>().ReverseMap();

        CreateMap<RevenueCategory, RevenueCategoryDTO>().ReverseMap();

        CreateMap<ExpenditureCategory, ExpenditureCategoryDTO>().ReverseMap();

        CreateMap<Revenue, RevenueDTO>().ReverseMap();

        CreateMap<Expenditure, ExpenditureDTO>().ReverseMap();
    }
}
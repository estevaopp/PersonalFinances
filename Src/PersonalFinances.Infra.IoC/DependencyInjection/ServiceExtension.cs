using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Application.Interfaces;
using PersonalFinances.Application.Services;

namespace PersonalFinances.Infra.IoC.DependencyInjection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<IRevenueService, RevenueService>();

            services.AddScoped<IRevenueCategoryService, RevenueCategoryService>();

            services.AddScoped<IExpenditureService, ExpenditureService>();

            services.AddScoped<IExpenditureCategoryService, ExpenditureCategoryService>();

            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
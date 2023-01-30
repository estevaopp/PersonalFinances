using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Repository;

namespace PersonalFinances.Infra.IoC.DependencyInjection
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped(typeof(IExpenditureCategoryRepository), typeof(ExpenditureCategoryRepository));

            services.AddScoped(typeof(IExpenditureRepository), typeof(ExpenditureRepository));

            services.AddScoped(typeof(IRevenueCategoryRepository), typeof(RevenueCategoryRepository));

            services.AddScoped(typeof(IRevenueRepository), typeof(RevenueRepository));

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            
            return services;
        }
    }
}
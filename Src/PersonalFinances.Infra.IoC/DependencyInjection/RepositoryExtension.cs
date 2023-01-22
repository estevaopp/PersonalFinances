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
            
            return services;
        }
    }
}
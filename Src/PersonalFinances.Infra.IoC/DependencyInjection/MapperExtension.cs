using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Application.Mappers;

namespace PersonalFinances.Infra.IoC.DependencyInjection
{
    public static class MapperExtension
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            
            return services;
        }
    }
}
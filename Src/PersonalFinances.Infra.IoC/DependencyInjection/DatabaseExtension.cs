using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Infra.Data.Context;

namespace PersonalFinances.Infra.IoC.DependencyInjection
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
                                  b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
            
            return services;
        }
    }
}
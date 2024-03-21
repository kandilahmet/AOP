using AOP.Application.Abstractions.Repositories;
using AOP.Persistence.EFCore;
using AOP.Persistence.EFCore.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MsSqlDbContext>();

            services.AddScoped(typeof(IReadRepository<>), typeof(EFCoreReadRepository<>));
        }
    }
}

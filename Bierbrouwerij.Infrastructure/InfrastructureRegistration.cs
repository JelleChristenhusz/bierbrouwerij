using Bierbrouwerij.Domain.Interfaces;
using Bierbrouwerij.Infrastructure.Data;
using Bierbrouwerij.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bierbrouwerij.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BierbrouwerijDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBierRepository, BierRepository>();

            return services;
        }
    }
}
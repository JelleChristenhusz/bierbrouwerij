using Bierbrouwerij.Application.Interfaces;
using Bierbrouwerij.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Bierbrouwerij.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IBierService, BierService>();

            return services;
        }
    }
}
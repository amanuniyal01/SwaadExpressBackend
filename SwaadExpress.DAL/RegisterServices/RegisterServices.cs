using Microsoft.Extensions.DependencyInjection;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.DAL.Repository;
using SwaadExpress.Interfaces.serviceInterface;
using SwaadExpress.Repositories;
using SwaadExpress.Services;

namespace SwaadExpress.DAL.RegisterServices
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterDependencies(
            this IServiceCollection services)
        {
            // Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
         

            // Repositories
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserOtpRepository, UserOtpRepository>();

            return services;
        }
    }
}
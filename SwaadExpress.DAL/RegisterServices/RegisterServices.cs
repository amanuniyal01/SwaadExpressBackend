using KaryaSync.ThirdPartyIntegrations.Services;
using Microsoft.Extensions.DependencyInjection;
using Resend;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.Application.Contracts.Service;
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

            // Email service (Resend)
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddHttpClient<ResendClient>();
            services.AddTransient<IResend, ResendClient>();

            return services;
        }
    }
}
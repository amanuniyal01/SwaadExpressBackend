using Microsoft.Extensions.DependencyInjection;
using SwaadExpress.Application.Contracts.Common;
using SwaadExpress.Application.Services;
using SwaadExpress.Domain.Modal.Common;
using System;


namespace SwaadExpress.DAL.RegisterServices
{
    public static class RegisterJwtServices
    {

        public static IServiceCollection RegisterJwtDependencies(
           this IServiceCollection services)
        {

            services.AddScoped<IJwtOptions, JwtOptions>();
            services.AddScoped<IJwtHandlerService, JwtHandlerService>();

            return services;
        }
    }
    
}

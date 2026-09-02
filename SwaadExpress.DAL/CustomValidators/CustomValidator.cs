using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SwaadExpress.Domain.Validators;


namespace SwaadExpress.DAL.CustomValidators
{
    public static class CustomValidator
    {
        public static IServiceCollection AddCustomValidators(this IServiceCollection services)

        {
            services.AddValidatorsFromAssemblyContaining<SendEmailOtpValidator>();
            return services;
        }
    }
}

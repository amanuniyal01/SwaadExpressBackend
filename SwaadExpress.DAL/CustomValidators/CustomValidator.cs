using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.DAL.CustomValidators
{
    public static class CustomValidator
    {
        public static IServiceCollection AddCustomValidators(this IServiceCollection services)
        {
            return services;
        }
    }
}

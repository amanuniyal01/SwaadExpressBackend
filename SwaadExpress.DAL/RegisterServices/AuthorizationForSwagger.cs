using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace KaryaSync.DAL.RegisterServices
{
    public static class AuthorizationForSwagger
    {
        public static IServiceCollection EnableKaryaSyncAuthorizationInSwagger(this IServiceCollection services)
        {
            services.Configure<SwaggerGenOptions>(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "KaryaSync API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Paste your JWT token only (Swagger adds 'Bearer ' for you).",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
                });
            });

            return services;
        }
    }
}
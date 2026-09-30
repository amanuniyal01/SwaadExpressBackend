using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Resend;
using SwaadExpress.Application.Contracts.Common;
using SwaadExpress.Application.Services;
using SwaadExpress.Domain.Modal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace SwaadExpress.DAL.RegisterServices
{
    public static class RegisterJwtServices
    {

        public static IServiceCollection RegisterJwtDependencies(
           this IServiceCollection services , IConfiguration configuration)
        {

            services.AddScoped<IJwtOptions, JwtOptions>();
            services.AddScoped<IJwtHandlerService, JwtHandlerService>();


            var jwtSettings = configuration.GetSection("ApiSettings:JwtOptions");
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var secret = jwtSettings["Secret"];

            var key = ASCIIEncoding.ASCII.GetBytes(secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>

                {
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        ValidateLifetime = true,

                        NameClaimType = JwtRegisteredClaimNames.Sub,
                    };


                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            // Get the token from the request
                            var token = context.Request.Headers["Authorization"]
                                .ToString()
                                .Replace("Bearer ", "");

                            if (string.IsNullOrEmpty(token))
                            {
                                context.Fail("Token is missing");
                                return;
                            }

                            //var jwtService =
                            //    context.HttpContext.RequestServices
                            //        .GetRequiredService<IJwtHandlerService>();

                            //JsonWebToken jwtToken =
                            //    context.SecurityToken as JsonWebToken;

                            //if (!await jwtService.IsTokenValid(jwtToken.EncodedToken))
                            //{
                            //    context.Fail("Invalid Token Details");
                            //}
                        }
                    };


                });
         

            return services;
        }
    }
    
}

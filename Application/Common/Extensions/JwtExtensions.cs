
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace Application.Common.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection AddAuthenticationPlatform(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration["Jwt:Issuer"];
                    options.Audience = Configuration["Jwt:Audience"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //  ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ValidateAudience = true,
                    };
                });
            return services;
        }

    }
}

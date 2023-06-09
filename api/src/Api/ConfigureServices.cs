﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen();
        services.AddControllers();

        services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            {
                // Allow multiple methods
                builder.WithMethods("GET", "POST", "PATCH", "DELETE")
                    .WithHeaders(
                        HeaderNames.Accept,
                        HeaderNames.ContentType,
                        HeaderNames.Authorization)
                    .SetIsOriginAllowed(origin =>
                    {
                        if (string.IsNullOrWhiteSpace(origin)) return false;
                        // Only add this to allow testing with localhost, remove this line in production!
                        if (origin.ToLower().Contains("localhost:3000")) return true;
                        // Insert your production domain here.
                        if (origin.ToLower().StartsWith("https://someone@example.com")) return true;
                        return false;
                    });
            })
        );

        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var a = 1 + 2;
            var b = 1 + 2;
            var c = 1 + 2;
            string key = "This is a sample secret key - please don't use in production environment.1";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = "JWT:Issuer",
                ValidAudience = "JWT:Audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false
            };
        });

        services.AddAuthorization();

        return services;
    }
}

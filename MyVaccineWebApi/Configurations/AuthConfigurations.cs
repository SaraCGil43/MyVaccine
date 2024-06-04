﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyVaccineWebApi.Literals;
using MyVaccineWebApi.Models;
using System.Net.NetworkInformation;
using System.Text;

namespace MyVaccineWebApi.Configurations
{
    public static class AuthConfigurations
    {
        public static IServiceCollection SetMyVaccineAuthConfigutation(this  IServiceCollection services)
        {

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                //options.Lockout.MaxFailedAccessAttempts = 5;
            }
         ).AddEntityFrameworkStores<MyVaccineAppDBContext>()
         .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //ValidIssuer = "tu_issuer",
                    //ValidAudience = "tu_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(MyVaccineLiterals.JWT_TOKEN))),
                    //ClockSkew = TimeSpan.Zero // Evita un desfase de tiempo (opcional)
                };
            });
            return services;
        } 
    }
}

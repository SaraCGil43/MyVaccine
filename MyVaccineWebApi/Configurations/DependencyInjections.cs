using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Repositories.Implementations;
using MyVaccineWebApi.Services.Contracts;
using MyVaccineWebApi.Services.Implementations;
using static MyVaccineWebApi.Services.GuidGeneratorService;

namespace MyVaccineWebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            #region Repositories Injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBaseRepository<Dependent>, BaseRepository<Dependent>>();
            #endregion

            #region Services Injection

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDependentService, DependentService>();
            #endregion

            #region Only for  testing propourses
            services.AddScoped<IGuidGeneratorScope, GuidServiceScope>();
            services.AddTransient<IGuidGeneratorTrasient, GuidServiceTransient>();
            services.AddSingleton<IGuidGeneratorSingleton, GuidServiceSingleton>();
            services.AddScoped<IGuidGeneratorDeep, GuidGeneratorDeep>();
            #endregion
            return services;
        }
    }
}
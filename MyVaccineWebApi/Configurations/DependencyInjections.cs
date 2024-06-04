using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Repositories.Implementations;
using MyVaccineWebApi.Services.Contracts;
using MyVaccineWebApi.Services.Implementations;

namespace MyVaccineWebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            #region Repositories Injection
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services Injection
            services.AddScoped<IUserService, UserService>();
            #endregion

            return services;
        }
    }
}
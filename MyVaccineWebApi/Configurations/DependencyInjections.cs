using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Repositories.Implementations;

namespace MyVaccineWebApi.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}

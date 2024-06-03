using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Configurations
{
    public static class DbConfigurations
    {
        public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            //var connectionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
            var connectionString = "Server=localhost,1433;Database=MyVaccineAppDb;User Id=sa;Password=Abc.123456;TrustServerCertificate=True;";
            services.AddDbContext<MyVaccineAppDBContext>(options =>
                        options.UseSqlServer(
                                    connectionString
                                    )
                        );
            return services;
        }

    }
}

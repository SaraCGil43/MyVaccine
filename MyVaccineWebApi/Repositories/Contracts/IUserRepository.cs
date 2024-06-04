using Microsoft.AspNetCore.Identity;
using MyVaccineWebApi.Dtos;
using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IUserRepository :IBaseRepository<User>
    {
        Task<IdentityResult> AddUser(RegisterRequestDto request);
    }
}

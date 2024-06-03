using Microsoft.AspNetCore.Identity;
using MyVaccineWebApi.Dtos;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUser(RegisterRequestDto request);
    }
}

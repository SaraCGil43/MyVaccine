using MyVaccineWebApi.Dtos;
using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthResponseDto> AddUserAsync(RegisterRequestDto request);
        Task<AuthResponseDto> Login(LoginRequestDto request);
        Task<AuthResponseDto> RefreshToken(string request);
        Task<User> GetUserInfo(string email);

    }
}

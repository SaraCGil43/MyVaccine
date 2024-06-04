using Microsoft.AspNetCore.Identity;
using MyVaccineWebApi.Dtos;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using System.Transactions;

namespace MyVaccineWebApi.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MyVaccineAppDBContext _context;
        public readonly UserManager<IdentityUser> _userManager;

        public UserRepository(MyVaccineAppDBContext context, UserManager<IdentityUser> userManager): base(context)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<IdentityResult> AddUser(RegisterRequestDto request)
        {
            var response = new IdentityResult();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = new ApplicationUser
                {
                    UserName = request.Username.ToLower(),
                    Email = request.Username
                };

                //Como es async hay un await
                var result = await _userManager.CreateAsync(user, request.Password);
                response = result;

                if (!result.Succeeded)
                {
                    return response;
                }

                var newUser = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    AspNetUserId = user.Id
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                scope.Complete();

            }

            return response;
        }
    }
}
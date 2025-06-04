
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User?> GetUserAsync(ClaimsPrincipal User) => await _userManager.GetUserAsync(User);
    }
}

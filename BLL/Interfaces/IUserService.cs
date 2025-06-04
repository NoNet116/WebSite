
using DAL.Entities;
using System.Security.Claims;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(ClaimsPrincipal User);
    }
}

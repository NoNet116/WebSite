using BLL.DTO;
using DAL.Entities;
using System.Security.Claims;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<(bool Succeeded, Dictionary<string, string>? Errors)> RegisterAsync(RegisterUserDTO model);
        Task<(User? User, Dictionary<string, string>? Errors)> LoginAsync(LoginUserDTO model);
        Task<bool> LogoutAsync();
        bool IsSign(ClaimsPrincipal User);
       
    }

}

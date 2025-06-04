using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<(bool Succeeded, Dictionary<string, string>? Errors)> RegisterAsync(RegisterUserDto model);
        Task<(bool Succeeded, Dictionary<string, string>? Errors)> LoginAsync(LoginUserDto model);
    }

}

using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using DAL.Entities;
using System.Security.Claims;

namespace BLL.Services;

    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

    public bool IsSign(ClaimsPrincipal User)
    {
        return _signInManager.IsSignedIn(User);
    }
    public async Task<bool> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return true;
    }

    public async Task<(bool Succeeded, Dictionary<string, string>?  Errors)> RegisterAsync(RegisterUserDTO model)
        {
            var errors = new Dictionary<string, string>();

            var existingUser = await _userManager.FindByEmailAsync(model.EmailReg);
            if (existingUser != null)
            {
                errors.Add("Email", "Пользователь с таким email уже существует.");
                return (false, errors);
            }

            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    switch (error.Code)
                    {
                        case "DuplicateUserName":
                            errors["UserName"] = "Имя пользователя уже занято.";
                            break;
                        default:
                            errors[string.Empty] = error.Description;
                            break;
                    }
                }
                return (false, errors);
            }
            return (true, null);
        }

        public async Task<(User? User, Dictionary<string, string>? Errors)> LoginAsync(LoginUserDTO model)
        {
            var errors = new Dictionary<string, string>();

            // Ищем пользователя по логину или email
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                errors["Email"] = "Пользователь не найден.";
                return (null, errors);
            }

            // Проверка пароля
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                errors["Password"] = "Неправильный пароль.";
                return (null, errors);
            }

            return (user, null);
        }
        
       


   
}

using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Data.Entities;

namespace BLL.Services
{
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

        public async Task<(bool Succeeded, Dictionary<string, string>?  Errors)> RegisterAsync(RegisterUserDto model)
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

            await _signInManager.SignInAsync(user, false);
            return (true, null);
        }
    }
}

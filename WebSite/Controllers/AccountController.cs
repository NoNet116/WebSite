using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.ViewModels.Account;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        private IMapper _mapper;
        private readonly IAccountService _accountService;


        public AccountController(IMapper mapper, IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }


        [Route("Registration")]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Registration", model);

            var dto = _mapper.Map<RegisterViewModel, RegisterUserDTO>(model);

            var (succeeded, errors) = await _accountService.RegisterAsync(dto);

            if (succeeded)
                return RedirectToAction("Index", "Home");

            var keyMap = new Dictionary<string, string>
            {
                ["Email"] = "EmailReg",
                ["Password"] = "PasswordReg"
            };

            foreach (var error in errors)
            {
                var key = keyMap.TryGetValue(error.Key, out string? value) ? value : error.Key;
                ModelState.AddModelError(key, error.Value);
            }

            return View("Registration", model);
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Home/Index.cshtml", model);

            var dto = _mapper.Map<LoginViewModel, LoginUserDTO>(model);

            var (user, errors) = await _accountService.LoginAsync(dto);

            if (user != null)
                return RedirectToAction("Index", "Profile", new { UserName = user.UserName});

            if (errors != null)
            {
                foreach (var error in errors)
                {
                    var key = error.Key;
                    var value = error.Value;
                    ModelState.AddModelError("Password", "Неправильный почтовый адрес или пароль.");
                }
            }

            return View("~/Views/Home/Index.cshtml", model);
        }

        
        [HttpPost]
     
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}

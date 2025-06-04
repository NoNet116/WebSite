using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSite.Models;
using WebSite.ViewModels.Account;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;


        public HomeController(ILogger<HomeController> logger, IAccountService accountService, IUserService userService )
        {
            _logger = logger;
            _accountService = accountService;
            _userService = userService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            var tmp = "asd";
            if (!_accountService.IsSign(User))
                return View(new LoginViewModel());

            var user = await _userService.GetUserAsync(User);

            return user == null
                ? NotFound()
                : RedirectToAction("Index", "Profile", new { UserName = user.UserName });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {

        [Route("Registration")]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}

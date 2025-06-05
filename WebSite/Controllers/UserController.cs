using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        
        public IActionResult Index(string username)
        {
            return View();
        }
    }
}

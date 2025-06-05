using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class FeedController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}

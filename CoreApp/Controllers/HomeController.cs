using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

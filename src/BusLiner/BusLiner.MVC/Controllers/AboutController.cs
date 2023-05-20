using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

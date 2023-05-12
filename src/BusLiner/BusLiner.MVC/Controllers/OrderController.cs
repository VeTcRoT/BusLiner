using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

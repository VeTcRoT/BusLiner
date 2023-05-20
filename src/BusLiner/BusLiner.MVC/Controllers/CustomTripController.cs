using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class CustomTripController : Controller
    {
        private readonly IMediator _mediator;

        public CustomTripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index() 
        {
            return View();
        }
    }
}

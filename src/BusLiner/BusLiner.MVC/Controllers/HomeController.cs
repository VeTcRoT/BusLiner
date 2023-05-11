using BusLiner.Application.Features.Rides.Queries.GetTopFiveRides;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var rides = await _mediator.Send(new GetTopFiveRidesQuery());

            return View(rides);
        }
    }
}

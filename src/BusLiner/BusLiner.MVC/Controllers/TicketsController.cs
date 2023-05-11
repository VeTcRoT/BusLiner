using BusLiner.Application.Features.Rides.Queries.GetRidesByOptions;
using BusLiner.MVC.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Index(GetRidesByOptionsQuery request)
        {
            Console.WriteLine(request.From);
            Console.WriteLine(request.To);
            Console.WriteLine(request.DepartureDate);

            var rides = await _mediator.Send(request);

            var vm = new TicketsVM()
            {
                From = request.From,
                To = request.To,
                DepartureDate = request.DepartureDate,
                Rides = rides,
            };

            return View(vm);
        }
    }
}

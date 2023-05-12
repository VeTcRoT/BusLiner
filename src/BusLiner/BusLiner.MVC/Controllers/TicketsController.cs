using BusLiner.Application.Features.ArrivalPlaces.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.ListAllDeparturePlaces;
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
            var rides = await _mediator.Send(request);

            var departurePlaces = await _mediator.Send(new ListAllDeparturePlacesQuery());
            var arrivalPlaces = await _mediator.Send(new ListAllArrivalPlacesQuery());

            var vm = new TicketsVM()
            {
                From = request.From,
                To = request.To,
                DeparturePlaces = departurePlaces,
                ArrivalPlaces = arrivalPlaces,
                DepartureDate = request.DepartureDate,
                Rides = rides,
            };

            return View(vm);
        }
    }
}

using BusLiner.Application.Features.ArrivalPlaces.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.ListAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Queries.GetTopFiveRides;
using BusLiner.MVC.ViewModel;
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

            var departurePlaces = await _mediator.Send(new ListAllDeparturePlacesQuery());
            var arrivalPlaces = await _mediator.Send(new ListAllArrivalPlacesQuery());

            var homeVm = new HomeVM()
            {
                DeparturePlaces = departurePlaces,
                ArrivalPlaces = arrivalPlaces,
                Rides = rides
            };

            return View(homeVm);
        }
    }
}

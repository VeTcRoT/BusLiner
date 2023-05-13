using BusLiner.Application.Features.ArrivalPlaces.Queries.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.ListAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Queries.GetRidesByOptions;
using BusLiner.Domain.Entities;
using BusLiner.MVC.Extensions;
using BusLiner.MVC.ViewModel;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<GetRidesByOptionsQuery> _validator;
        public TicketsController(IMediator mediator, IValidator<GetRidesByOptionsQuery> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }
        [HttpPost]
        public async Task<IActionResult> Index(GetRidesByOptionsQuery request)
        {
            var departurePlaces = await _mediator.Send(new ListAllDeparturePlacesQuery());
            var arrivalPlaces = await _mediator.Send(new ListAllArrivalPlacesQuery());

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid) 
            {
                validationResult.AddToModelState(ModelState);

                var vmNotValid = new TicketsVM()
                {
                    From = request.From,
                    To = request.To,
                    DeparturePlaces = departurePlaces,
                    ArrivalPlaces = arrivalPlaces,
                    DepartureDate = request.DepartureDate,
                    Rides = new List<Ride>()
                };

                return View(vmNotValid);
            }

            var rides = await _mediator.Send(request);

            var vm = new TicketsVM()
            {
                From = request.From,
                To = request.To,
                DeparturePlaces = departurePlaces,
                ArrivalPlaces = arrivalPlaces,
                DepartureDate = request.DepartureDate,
                Rides = rides
            };

            return View(vm);
        }
    }
}

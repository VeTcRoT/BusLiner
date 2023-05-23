using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Commands.UpdateRide;
using BusLiner.Application.Features.Rides.Queries.GetRideById;
using BusLiner.Domain.Entities;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Rides
{
    public class UpdateRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; } = null!;
        public IEnumerable<GetAllDeparturePlacesDto> DeparturePlaces { get; set; } = null!;
        public IEnumerable<GetAllArrivalPlacesDto> ArrivalPlaces { get; set; } = null!;

        public int DepId { get; set; }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateRideCommand> _validator;

        public UpdateRideModel(IMediator mediator, IMapper mapper, IValidator<UpdateRideCommand> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int rideId;

            if (!int.TryParse(Request.Query["RideId"], out rideId))
                return RedirectToPage("AllRides");

            Ride = await _mediator.Send(new GetRideByIdQuery() { Id = rideId });
            DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());
            ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateRideCommand>(Ride);

            var validationResult = await _validator.ValidateAsync(mapped);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "Ride");
                DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());
                ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());
                return Page();
            }

            await _mediator.Send(mapped);

            return RedirectToPage("AllRides");
        }
    }
}

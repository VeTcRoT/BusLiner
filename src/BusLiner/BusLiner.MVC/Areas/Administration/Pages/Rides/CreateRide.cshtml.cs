using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Commands.CreateRide;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Rides
{
    public class CreateRideModel : PageModel
    {
        [BindProperty]
        public CreateRideCommand Ride { get; set; } = null!;
        public IEnumerable<GetAllDeparturePlacesDto> DeparturePlaces { get; set; } = null!;
        public IEnumerable<GetAllArrivalPlacesDto> ArrivalPlaces { get; set; } = null!;

        public int DepId { get; set; }

        private readonly IMediator _mediator;
        private readonly IValidator<CreateRideCommand> _validator;

        public CreateRideModel(IMediator mediator, IValidator<CreateRideCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public async Task<PageResult> OnGetAsync()
        {
            DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());
            ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var validationResult = await _validator.ValidateAsync(Ride);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "Ride");
                DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());
                ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());
                return Page();
            }

            await _mediator.Send(Ride);

            return RedirectToPage("AllRides");
        }
    }
}

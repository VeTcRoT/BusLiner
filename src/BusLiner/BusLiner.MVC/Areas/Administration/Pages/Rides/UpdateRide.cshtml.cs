using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Commands.UpdateRide;
using BusLiner.Application.Features.Rides.Queries.GetRideById;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Rides
{
    public class UpdateRideModel : PageModel
    {
        [BindProperty]
        public Ride Ride { get; set; }
        public IEnumerable<GetAllDeparturePlacesDto> DeparturePlaces { get; set; }
        public IEnumerable<GetAllArrivalPlacesDto> ArrivalPlaces { get; set; }

        public int DepId { get; set; }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateRideModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PageResult> OnGetAsync()
        {
            var rideId = Convert.ToInt32(Request.Query["RideId"]);

            Ride = await _mediator.Send(new GetRideByIdQuery() { Id = rideId });
            DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());
            ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateRideCommand>(Ride);

            await _mediator.Send(mapped);

            return RedirectToPage("AllRides");
        }
    }
}

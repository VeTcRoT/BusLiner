using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Commands.CreateRide;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Rides
{
    public class CreateRideModel : PageModel
    {
        [BindProperty]
        public CreateRideCommand Ride { get; set; }
        public IEnumerable<GetAllDeparturePlacesDto> DeparturePlaces { get; set; }
        public IEnumerable<GetAllArrivalPlacesDto> ArrivalPlaces { get; set; }

        public int DepId { get; set; }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateRideModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PageResult> OnGetAsync()
        {
            DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());
            ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(Ride);

            return RedirectToPage("AllRides");
        }
    }
}

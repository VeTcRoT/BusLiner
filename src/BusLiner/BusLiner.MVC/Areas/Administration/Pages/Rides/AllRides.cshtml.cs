using BusLiner.Application.Features.Rides.Commands.DeleteRide;
using BusLiner.Application.Features.Rides.Queries.GetAllRides;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Rides
{
    public class AllRidesModel : PageModel
    {
        [BindProperty]
        public int RideId { get; set; }
        public IEnumerable<Ride> Rides { get; set; } = null!;

        private readonly IMediator _mediator;

        public AllRidesModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PageResult> OnGetAsync()
        {
            Rides = await _mediator.Send( new GetAllRidesQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(new DeleteRideCommand() { RideId = RideId } );
            return RedirectToPage("AllRides");
        }
    }
}

using BusLiner.Application.Features.CustomTrips.Commands.DeleteCustomTrip;
using BusLiner.Application.Features.CustomTrips.Queries.GetAllCustomTrips;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.CustomTrips
{
    public class AllCustomTripsModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public IEnumerable<CustomTrip> CustomTrips { get; set; } = null!;

        private readonly IMediator _mediator;

        public AllCustomTripsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CustomTrips = await _mediator.Send( new GetAllCustomTripsQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send( new DeleteCustomTripCommand() { Id = Id } );

            return RedirectToPage("AllCustomTrips");
        }
    }
}

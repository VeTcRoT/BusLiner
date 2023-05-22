using BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.CustomTrips
{
    public class CreateCustomTripModel : PageModel
    {
        [BindProperty]
        public AddCustomTripCommand CustomTrip { get; set; } = null!;

        private readonly IMediator _mediator;

        public CreateCustomTripModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(CustomTrip);

            return RedirectToPage("AllCustomTrips");
        }
    }
}

using BusLiner.Application.Features.DeparturePlaces.Commands.CreateDeparturePlace;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class CreateDeparturePlaceModel : PageModel
    {
        [BindProperty]
        public CreateDeparturePlaceCommand DeparturePlace { get; set; } = null!;

        private readonly IMediator _mediator;

        public CreateDeparturePlaceModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(DeparturePlace);

            return RedirectToPage("AllDeparturePlaces");
        }
    }
}

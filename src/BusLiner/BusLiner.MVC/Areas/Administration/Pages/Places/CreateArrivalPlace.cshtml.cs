using BusLiner.Application.Features.ArrivalPlaces.Commands.CreateArrivalPlace;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class CreateArrivalPlaceModel : PageModel
    {
        [BindProperty]
        public CreateArrivalPlaceCommand ArrivalPlace { get; set; }

        private readonly IMediator _mediator;

        public CreateArrivalPlaceModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(ArrivalPlace);

            return RedirectToPage("AllArrivalPlaces");
        }
    }
}

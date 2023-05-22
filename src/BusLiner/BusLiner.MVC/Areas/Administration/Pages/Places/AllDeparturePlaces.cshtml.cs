using BusLiner.Application.Features.DeparturePlaces.Commands.DeleteDeparturePlace;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class AllDeparturePlacesModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public IEnumerable<GetAllDeparturePlacesDto> DeparturePlaces { get; set; } = null!;

        private readonly IMediator _mediator;

        public AllDeparturePlacesModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            DeparturePlaces = await _mediator.Send(new GetAllDeparturePlacesQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(new DeleteDeparturePlaceCommand() { Id = Id });

            return RedirectToPage("AllDeparturePlaces");
        }
    }
}

using BusLiner.Application.Features.ArrivalPlaces.Commands.DeleteArrivalPlace;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Commands.DeleteDeparturePlace;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class AllArrivalPlacesModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public IEnumerable<GetAllArrivalPlacesDto> ArrivalPlaces { get; set; }

        private readonly IMediator _mediator;

        public AllArrivalPlacesModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ArrivalPlaces = await _mediator.Send(new GetAllArrivalPlacesQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(new DeleteArrivalPlaceCommand() { Id = Id });

            return RedirectToPage("AllArrivalPlaces");
        }
    }
}

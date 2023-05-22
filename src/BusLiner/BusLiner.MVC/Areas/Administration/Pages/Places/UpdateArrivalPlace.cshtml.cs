using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Commands.UpdateArrivalPlace;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetArrivalPlaceById;
using BusLiner.Application.Features.DeparturePlaces.Commands.UpdateDeparturePlace;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class UpdateArrivalPlaceModel : PageModel
    {
        [BindProperty]
        public ArrivalPlace ArrivalPlace { get; set; } = null!;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateArrivalPlaceModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var arrPlaceId = Convert.ToInt32(Request.Query["Id"]);

            ArrivalPlace = await _mediator.Send(new GetArrivalPlaceByIdQuery() { Id = arrPlaceId });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateArrivalPlaceCommand>(ArrivalPlace);

            await _mediator.Send(mapped);

            return RedirectToPage("AllArrivalPlaces");
        }
    }
}

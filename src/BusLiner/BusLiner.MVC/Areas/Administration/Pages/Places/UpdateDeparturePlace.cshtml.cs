using AutoMapper;
using BusLiner.Application.Features.DeparturePlaces.Commands.UpdateDeparturePlace;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetDeparturePlaceById;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class UpdateDeparturePlaceModel : PageModel
    {
        [BindProperty]
        public DeparturePlace DeparturePlace { get; set; }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateDeparturePlaceModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var depPlaceId = Convert.ToInt32(Request.Query["Id"]);

            DeparturePlace = await _mediator.Send(new GetDeparturePlaceByIdQuery() { Id = depPlaceId });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateDeparturePlaceCommand>(DeparturePlace);

            await _mediator.Send(mapped);

            return RedirectToPage("AllDeparturePlaces");
        }
    }
}

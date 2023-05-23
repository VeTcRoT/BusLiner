using AutoMapper;
using BusLiner.Application.Features.CustomTrips.Commands.UpdateCustomTrip;
using BusLiner.Application.Features.CustomTrips.Queries.GetCustomTripById;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.CustomTrips
{
    public class UpdateCustomTripModel : PageModel
    {
        [BindProperty]
        public CustomTrip CustomTrip { get; set; } = null!;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateCustomTripModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int tripId;

            if (!int.TryParse(Request.Query["Id"], out tripId))
                return RedirectToPage("AllCustomTrips");

            CustomTrip = await _mediator.Send( new GetCustomTripByIdQuery() { Id = tripId } );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateCustomTripCommand>(CustomTrip);

            await _mediator.Send(mapped);

            return RedirectToPage("AllCustomTrips");
        }
    }
}

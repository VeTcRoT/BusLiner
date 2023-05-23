using AutoMapper;
using BusLiner.Application.Features.CustomTrips.Commands.UpdateCustomTrip;
using BusLiner.Application.Features.CustomTrips.Queries.GetCustomTripById;
using BusLiner.Domain.Entities;
using BusLiner.MVC.Extensions;
using FluentValidation;
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
        private readonly IValidator<UpdateCustomTripCommand> _validator;

        public UpdateCustomTripModel(IMediator mediator, IMapper mapper, IValidator<UpdateCustomTripCommand> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
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

            var validationResult = await _validator.ValidateAsync(mapped);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "CustomTrip");
                return Page();
            }

            await _mediator.Send(mapped);

            return RedirectToPage("AllCustomTrips");
        }
    }
}

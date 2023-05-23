using BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip;
using BusLiner.MVC.Extensions;
using FluentValidation;
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
        private readonly IValidator<AddCustomTripCommand> _validator;

        public CreateCustomTripModel(IMediator mediator, IValidator<AddCustomTripCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var validationResult = await _validator.ValidateAsync(CustomTrip);

            if (!validationResult.IsValid) 
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "CustomTrip");
                return Page();
            }

            await _mediator.Send(CustomTrip);

            return RedirectToPage("AllCustomTrips");
        }
    }
}

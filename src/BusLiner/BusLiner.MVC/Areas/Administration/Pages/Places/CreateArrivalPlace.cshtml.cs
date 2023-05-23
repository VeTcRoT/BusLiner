using BusLiner.Application.Features.ArrivalPlaces.Commands.CreateArrivalPlace;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Places
{
    public class CreateArrivalPlaceModel : PageModel
    {
        [BindProperty]
        public CreateArrivalPlaceCommand ArrivalPlace { get; set; } = null!;

        private readonly IMediator _mediator;
        private readonly IValidator<CreateArrivalPlaceCommand> _validator;

        public CreateArrivalPlaceModel(IMediator mediator, IValidator<CreateArrivalPlaceCommand> validator)
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
            var validationResult = await _validator.ValidateAsync(ArrivalPlace);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "ArrivalPlace");
                return Page();
            }

            await _mediator.Send(ArrivalPlace);

            return RedirectToPage("AllArrivalPlaces");
        }
    }
}

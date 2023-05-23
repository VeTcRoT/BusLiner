using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Commands.UpdateArrivalPlace;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetArrivalPlaceById;
using BusLiner.Domain.Entities;
using BusLiner.MVC.Extensions;
using FluentValidation;
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
        private readonly IValidator<UpdateArrivalPlaceCommand> _validator;

        public UpdateArrivalPlaceModel(IMediator mediator, IMapper mapper, IValidator<UpdateArrivalPlaceCommand> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int arrPlaceId;

            if (!int.TryParse(Request.Query["Id"], out arrPlaceId))
                return RedirectToPage("AllArrivalPlaces");

            ArrivalPlace = await _mediator.Send(new GetArrivalPlaceByIdQuery() { Id = arrPlaceId });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateArrivalPlaceCommand>(ArrivalPlace);

            var validationResult = await _validator.ValidateAsync(mapped);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "ArrivalPlace");
                return Page();
            }

            await _mediator.Send(mapped);

            return RedirectToPage("AllArrivalPlaces");
        }
    }
}

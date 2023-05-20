using BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class CustomTripController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddCustomTripCommand> _validator;

        public CustomTripController(IMediator mediator, IValidator<AddCustomTripCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SaveCustomTrip(AddCustomTripCommand request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);

                return View("Index", request);
            }

            await _mediator.Send(request);

            return RedirectToAction("Index", "Home");
        }
    }
}

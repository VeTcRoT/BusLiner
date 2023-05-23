using AutoMapper;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        [BindProperty]
        public CreateOrderQuery Order { get; set; } = null!;

        private readonly IMediator _mediator;
        private readonly IValidator<CreateOrderQuery> _validator;

        public CreateOrderModel(IMediator mediator, IValidator<CreateOrderQuery> validator)
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
            var validationResult = _validator.Validate(Order);

            if (!validationResult.IsValid) 
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "Order");

                return Page();
            }

            await _mediator.Send(Order);

            return RedirectToPage("AllOrders");
        }
    }
}

using AutoMapper;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Application.Features.Orders.Commands.UpdateOrder;
using BusLiner.Application.Features.Orders.Queries.GetOrderById;
using BusLiner.Domain.Entities;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Orders
{
    public class UpdateOrderModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; } = null!;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateOrderCommand> _validator;

        public UpdateOrderModel(IMediator mediator, IMapper mapper, IValidator<UpdateOrderCommand> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int orderId;

            if (!int.TryParse(Request.Query["Id"], out orderId))
                return RedirectToPage("AllOrders");

            Order = await _mediator.Send( new GetOrderByIdQuery() { Id = orderId } );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateOrderCommand>(Order);

            var validationResult = await _validator.ValidateAsync(mapped);

            if (!validationResult.IsValid) 
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "Order");
                return Page();
            }

            await _mediator.Send(mapped);

            return RedirectToPage("AllOrders");
        }
    }
}

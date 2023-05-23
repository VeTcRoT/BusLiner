using AutoMapper;
using BusLiner.Application.Features.Orders.Commands.UpdateOrder;
using BusLiner.Application.Features.Orders.Queries.GetOrderById;
using BusLiner.Domain.Entities;
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

        public UpdateOrderModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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

            await _mediator.Send(mapped);

            return RedirectToPage("AllOrders");
        }
    }
}

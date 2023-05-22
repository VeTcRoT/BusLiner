using AutoMapper;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
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

        public CreateOrderModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(Order);

            return RedirectToPage("AllOrders");
        }
    }
}

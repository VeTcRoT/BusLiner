using BusLiner.Application.Features.Orders.Commands.DeleteOrder;
using BusLiner.Application.Features.Orders.Queries.GetAllOrders;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Orders
{
    public class AllOrdersModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public IEnumerable<Order> Orders { get; set; } = null!;

        private readonly IMediator _mediator;
        public AllOrdersModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _mediator.Send(new GetAllOrdersQuery());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(new DeleteOrderCommand() { Id = Id });

            return RedirectToPage("AllOrders");
        }
    }
}

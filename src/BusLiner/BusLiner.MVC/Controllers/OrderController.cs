using BusLiner.Application.Features.Rides.Queries.GetRideById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int rideId)
        {
            var ride = await _mediator.Send(new GetRideByIdQuery() { Id = rideId });

            return View(ride);
        }
    }
}

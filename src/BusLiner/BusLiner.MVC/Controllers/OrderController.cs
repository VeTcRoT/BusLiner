using AutoMapper;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Application.Features.Rides.Queries.GetRideById;
using BusLiner.Domain.Entities;
using BusLiner.MVC.Extensions;
using BusLiner.MVC.ViewModel;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusLiner.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateOrderQuery> _validator;
        private readonly IMapper _mapper;
        private static Ride Ride = null!;

        public OrderController(IMediator mediator, IValidator<CreateOrderQuery> validator, IMapper mapper)
        {
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int rideId)
        {
            var ride = await _mediator.Send(new GetRideByIdQuery() { Id = rideId });

            Ride = ride;

            var orderVm = new OrderVM() { Ride = ride };

            return View(orderVm);
        }

        public async Task<IActionResult> Order(CreateOrderQuery request)
        {
            request.RideId = Ride.Id;

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid) 
            {
                validationResult.AddToModelState(ModelState);

                var orderVm = _mapper.Map<OrderVM>(request);

                orderVm.Ride = Ride;

                return View("Index", orderVm);
            }

            await _mediator.Send(request);

            return View("ThanksForOrder");
        }

        public IActionResult ThanksForOrder()
        {
            return View();
        }
    }
}

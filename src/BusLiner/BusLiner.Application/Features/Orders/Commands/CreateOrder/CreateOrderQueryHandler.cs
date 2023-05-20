using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Security.Cryptography;
using System.Text;

namespace BusLiner.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderQueryHandler : IRequestHandler<CreateOrderQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task Handle(CreateOrderQuery request, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<Order>(request);

            await _unitOfWork.OrderRepository.AddAsync(mappedRequest);

            var rideToChange = await _unitOfWork.RideRepository.GetRideByIdAsync(request.RideId);

            if (rideToChange == null)
                throw new NotFoundException(nameof(Ride), request.RideId);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                var dataToHash = rideToChange.DeparturePlace.City + rideToChange.ArrivalPlace.City + rideToChange.Id;

                mappedRequest.TicketCode = Convert.ToHexString(
                    sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(dataToHash)));
            }

            rideToChange.TicketsAvailable -= request.TicketsOrdered;

            await _unitOfWork.SaveAsync();

            var email = $"<!DOCTYPE html> <html> <head> <title>Лист про успішну покупку квитка</title> <style> body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }} .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 5px; box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); }} h1 {{ color: #333333; text-align: center; }} p {{ color: #666666; line-height: 1.6; }} </style> </head> <body> <div class=\"container\"> <h1>Успішна покупка квитка!</h1> <p>Дякуємо за покупку квитка! Ваш квиток був успішно придбаний.</p> <p>Інформація про квиток:</p> <ul> <li><strong>Поїздка:</strong> {rideToChange.DeparturePlace.City} - {rideToChange.ArrivalPlace.City}</li> <li><strong>Дата та час посадки:</strong> {rideToChange.DepartureTime}</li> <li><strong>Дата та час прибуття:</strong> {rideToChange.ArrivalTime}</li> <li><strong>Замовлено квитків:</strong> {request.TicketsOrdered} шт.</li> <li><strong>Додаткового багажу:</strong> {request.AdditionalBaggage} шт.</li> <li><strong>Ціна:</strong> {request.Total} грн.</li> <li><strong>Номер квитка:</strong> {mappedRequest.TicketCode}</li> </ul> <p>Цей лист необхідно пред'явити водієві перед посадкою на автобус.</p> <p>Якщо у вас виникли питання або потрібна додаткова інформація, будь ласка, зв'яжіться з нашою службою підтримки.</p> <p>Дякуємо ще раз!</p> <p>З повагою,</p> <p>Команда Busliner</p> </div> </body> </html>";

            await _emailSender.SendEmailAsync(request.Email, "Покупка квитка", email);
        }
    }
}

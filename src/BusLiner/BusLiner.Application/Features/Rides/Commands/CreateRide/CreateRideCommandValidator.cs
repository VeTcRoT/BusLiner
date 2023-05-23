using FluentValidation;

namespace BusLiner.Application.Features.Rides.Commands.CreateRide
{
    public class CreateRideCommandValidator : AbstractValidator<CreateRideCommand>
    {
        public CreateRideCommandValidator()
        {
            RuleFor(r => r.TicketsAvailable)
                .GreaterThanOrEqualTo(30).WithMessage("К-сть квитків не може бути меншою за 30.")
                .LessThanOrEqualTo(100).WithMessage("К-сть квитків не може бути більшою за 200.");

            RuleFor(r => r.Price)
                .GreaterThan(0).WithMessage("Ціна не можу бути меншою або рівною 0.");

            RuleFor(r => r.DeparturePlaceId)
                .GreaterThan(0).WithMessage("DeparturePlaceId не може бути меншим або рівним 0.");

            RuleFor(r => r.ArrivalPlaceId)
                .GreaterThan(0).WithMessage("ArrivalPlaceId не може бути меншим або рівним 0.");

            RuleFor(r => r)
                .Must(ArrivalTimeGreaterThanDepartureTime).WithMessage("Дата відправки не може бути більшою або рівною даті прибуття.");
        }
        private bool ArrivalTimeGreaterThanDepartureTime(CreateRideCommand ride)
        {
            return ride.ArrivalTime > ride.DepartureTime;
        }
    }
}

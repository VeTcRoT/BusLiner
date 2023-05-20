using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip
{
    public class AddCustomTripCommand : IRequest
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public int AmountOfPassengers { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

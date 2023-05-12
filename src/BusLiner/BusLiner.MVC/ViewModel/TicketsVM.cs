using BusLiner.Application.Features.ArrivalPlaces.Queries.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.ListAllDeparturePlaces;
using BusLiner.Domain.Entities;

namespace BusLiner.MVC.ViewModel
{
    public class TicketsVM
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public IEnumerable<ListAllDeparturePlacesDto> DeparturePlaces { get; set; } = null!;
        public IEnumerable<ListAllArrivalPlacesDto> ArrivalPlaces { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public IEnumerable<Ride> Rides { get; set; } = null!;
    }
}

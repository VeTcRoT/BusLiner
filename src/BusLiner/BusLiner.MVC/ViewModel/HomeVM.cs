using BusLiner.Application.Features.ArrivalPlaces.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.ListAllDeparturePlaces;
using BusLiner.Domain.Entities;

namespace BusLiner.MVC.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<ListAllDeparturePlacesDto> DeparturePlaces { get; set; } = null!;
        public IEnumerable<ListAllArrivalPlacesDto> ArrivalPlaces { get; set; } = null!;
        public IEnumerable<Ride> Rides { get; set; } = null!;
    }
}

using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.ListAllDeparturePlaces;
using BusLiner.Application.Features.Rides.Queries.GetRideById;
using BusLiner.Domain.Entities;

namespace BusLiner.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ride, GetRideByIdDto>();

            CreateMap<DeparturePlace, ListAllDeparturePlacesDto>();
            CreateMap<ArrivalPlace, ListAllArrivalPlacesDto>();
        }
    }
}

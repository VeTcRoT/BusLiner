using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Queries.ListAllArrivalPlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.ListAllDeparturePlaces;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail;
using BusLiner.Domain.Entities;

namespace BusLiner.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeparturePlace, ListAllDeparturePlacesDto>();
            CreateMap<ArrivalPlace, ListAllArrivalPlacesDto>();

            CreateMap<CreateOrderQuery, Order>();

            CreateMap<Ride, GetUserRidesByEmailDto>();
        }
    }
}

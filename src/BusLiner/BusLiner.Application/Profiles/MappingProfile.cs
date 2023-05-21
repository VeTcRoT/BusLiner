using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.ArrivalPlaces.Queries.ListAllArrivalPlaces;
using BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.ListAllDeparturePlaces;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail;
using BusLiner.Application.Features.Rides.Commands.CreateRide;
using BusLiner.Application.Features.Rides.Commands.UpdateRide;
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

            CreateMap<AddCustomTripCommand, CustomTrip>();

            CreateMap<DeparturePlace, GetAllDeparturePlacesDto>();
            CreateMap<ArrivalPlace, GetAllArrivalPlacesDto>();

            CreateMap<UpdateRideCommand, Ride>().ReverseMap();

            CreateMap<CreateRideCommand, Ride>();
        }
    }
}

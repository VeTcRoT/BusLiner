using AutoMapper;
using BusLiner.Application.Features.ArrivalPlaces.Commands.CreateArrivalPlace;
using BusLiner.Application.Features.ArrivalPlaces.Commands.UpdateArrivalPlace;
using BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces;
using BusLiner.Application.Features.ArrivalPlaces.Queries.ListAllArrivalPlaces;
using BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip;
using BusLiner.Application.Features.CustomTrips.Commands.UpdateCustomTrip;
using BusLiner.Application.Features.DeparturePlaces.Commands.CreateDeparturePlace;
using BusLiner.Application.Features.DeparturePlaces.Commands.UpdateDeparturePlace;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Application.Features.DeparturePlaces.Queries.ListAllDeparturePlaces;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Application.Features.Orders.Commands.UpdateOrder;
using BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail;
using BusLiner.Application.Features.Rides.Commands.CreateRide;
using BusLiner.Application.Features.Rides.Commands.UpdateRide;
using BusLiner.Application.Features.Roles.Queries.GetAllRoles;
using BusLiner.Application.Features.Users.Commands.UpdateUser;
using BusLiner.Application.Features.Users.Queries.GetAllUsers;
using BusLiner.Application.Features.Users.Queries.GetUserById;
using BusLiner.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeparturePlace, ListAllDeparturePlacesDto>();
            CreateMap<ArrivalPlace, ListAllArrivalPlacesDto>();

            CreateMap<CreateOrderQuery, Order>();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();

            CreateMap<Ride, GetUserRidesByEmailDto>();

            CreateMap<AddCustomTripCommand, CustomTrip>();
            CreateMap<UpdateCustomTripCommand, CustomTrip>().ReverseMap();

            CreateMap<DeparturePlace, GetAllDeparturePlacesDto>();
            CreateMap<ArrivalPlace, GetAllArrivalPlacesDto>();

            CreateMap<UpdateRideCommand, Ride>().ReverseMap();

            CreateMap<CreateRideCommand, Ride>();

            CreateMap<CreateDeparturePlaceCommand, DeparturePlace>();
            CreateMap<UpdateDeparturePlaceCommand, DeparturePlace>().ReverseMap();

            CreateMap<CreateArrivalPlaceCommand, ArrivalPlace>();
            CreateMap<UpdateArrivalPlaceCommand, ArrivalPlace>().ReverseMap();

            CreateMap<IdentityUser, GetUserByIdDto>();

            CreateMap<IdentityUser, GetAllUsersDto>();

            CreateMap<IdentityRole, GetAllRolesDto>();

            CreateMap<GetUserByIdDto, UpdateUserCommand>();
        }
    }
}

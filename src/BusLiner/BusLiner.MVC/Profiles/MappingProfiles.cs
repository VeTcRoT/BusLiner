using AutoMapper;
using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Domain.Entities;
using BusLiner.MVC.ViewModel;

namespace BusLiner.MVC.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOrderQuery, OrderVM>();
        }
    }
}

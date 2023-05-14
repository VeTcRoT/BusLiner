using BusLiner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusLiner.Persistence
{
    public class BusLinerDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Ride> Rides { get; set; } = null!;
        public DbSet<DeparturePlace> DeparturePlaces { get; set; } = null!;
        public DbSet<ArrivalPlace> ArrivalPlaces { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public BusLinerDbContext(DbContextOptions<BusLinerDbContext> options) : base(options) { }
    }
}

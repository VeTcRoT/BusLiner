using BusLiner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusLiner.Persistence
{
    public class BusLinerDbContext : DbContext
    {
        public DbSet<Ride> Rides { get; set; } = null!;
        public DbSet<DeparturePlace> DeparturePlaces { get; set; } = null!;
        public DbSet<ArrivalPlace> ArrivalPlaces { get; set; } = null!;
        public BusLinerDbContext(DbContextOptions<BusLinerDbContext> options) : base(options) { }
    }
}

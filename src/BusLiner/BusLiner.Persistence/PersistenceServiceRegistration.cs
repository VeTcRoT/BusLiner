using BusLiner.Domain.Interfaces.Repositories;
using BusLiner.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusLiner.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRideRepository, RideRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

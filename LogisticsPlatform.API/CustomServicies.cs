using System.Reflection;
using LogisticsPlatform.Application.Command.Vehicle;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticsPlatform.API
{
    public static class CustomServicies
    {
        /// <summary>
        /// Agrega los diferentes servicio personalizados de la aplicación.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <returns>IServiceCollection with dependencies.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Add MediatR Commands/Events.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddOrderVehicleCommand).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateVehicleCommand).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteOrderVehicleCommand).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateLocationVehicleCommand).GetTypeInfo().Assembly));

            // Add IoC references.
            services.AddTransient<Application.Interfaces.IVehicleQueries, Application.Queries.VehicleQueries>();
            services.AddScoped<Application.Interfaces.IVehicleRepository, Infrastructure.Rpositories.VehicleRepository>();
            services.AddScoped<Application.Interfaces.IVehicleQueries, Infrastructure.Queries.VehicleRepositoryQueries>();

            // Add auto mapper
            services.AddAutoMapper(typeof(Application.Mapping.MappingProfile));

            return services;
        }
    }
}

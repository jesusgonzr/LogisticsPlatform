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
            services.AddTransient<Application.Interfaces.IVehicleRepository, Infrastructure.Rpositories.VehicleRepository>();
            services.AddTransient<Application.Interfaces.IVehicleRepositoryQueries, Infrastructure.Queries.VehicleRepositoryQueries>();

            services.AddTransient<Application.Interfaces.IOrderQueries, Application.Queries.OrderQueries>();
            services.AddTransient<Application.Interfaces.IOrderRepositoryQueries, Infrastructure.Queries.OrderRepositoryQueries>();
            services.AddTransient<Application.Interfaces.INotificationServices, Infrastructure.Services.NotificationServices>();
            services.AddTransient<Infrastructure.Hubs.NotificationHub>();

            // Add auto mapper
            services.AddAutoMapper(typeof(Application.Mapping.MappingProfile));

            return services;
        }
    }
}

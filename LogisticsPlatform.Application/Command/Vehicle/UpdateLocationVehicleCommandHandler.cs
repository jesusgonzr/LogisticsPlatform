using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class UpdateLocationVehicleCommandHandler : IRequestHandler<UpdateLocationVehicleCommand, VehicleViewModel>
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IVehicleRepositoryQueries vehicleRepositoryQueries;
        private readonly ILogger<UpdateLocationVehicleCommandHandler> logger;
        private readonly INotificationServices notificationServices;

        public UpdateLocationVehicleCommandHandler(IMapper mapper, ILogger<UpdateLocationVehicleCommandHandler> logger,
            IVehicleRepository repository, IVehicleRepositoryQueries vehicleRepositoryQueries,
            INotificationServices notificationServices)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.vehicleRepositoryQueries = vehicleRepositoryQueries ?? throw new ArgumentNullException(nameof(vehicleRepositoryQueries));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.notificationServices = notificationServices ?? throw new ArgumentNullException(nameof(notificationServices));
        }

        public Task<VehicleViewModel> Handle(UpdateLocationVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var vehicleData = this.vehicleRepositoryQueries.GetbyId(request.Id);
                if (vehicleData == null)
                {
                    string menssage = $"El vehiculo {request.Id} no existe.";
                    this.logger.LogError(menssage);
                    throw new Exception(menssage);
                }

                vehicleData.AddLocation(request.Latitude, request.Longitude);

                repository.Update(vehicleData);

                try
                {
                    foreach (var item in vehicleData.Orders)
                    {
                        notificationServices.PublishAsync(item.Id, request.Latitude, request.Longitude);
                    }
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, "Error al notificar el cambio de localizcion del vehiculo.", request);
                }

                return Task.FromResult<VehicleViewModel>(this.mapper.Map<VehicleViewModel>(vehicleData));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error creating a product.", request);
                throw;
            }
        }
    }
}

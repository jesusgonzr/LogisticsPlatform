using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class AddOrderVehicleCommandHandler : IRequestHandler<AddOrderVehicleCommand, VehicleViewModel>
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IOrderRepositoryQueries orderRepositoryQueries;
        private readonly IVehicleRepositoryQueries vehicleRepositoryQueries;
        private readonly ILogger<AddOrderVehicleCommandHandler> logger;

        public AddOrderVehicleCommandHandler(IMapper mapper, ILogger<AddOrderVehicleCommandHandler> logger,
            IVehicleRepository repository, IVehicleRepositoryQueries vehicleRepositoryQueries,
            IOrderRepositoryQueries orderRepositoryQueries)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.orderRepositoryQueries = orderRepositoryQueries ?? throw new ArgumentNullException(nameof(orderRepositoryQueries));
            this.vehicleRepositoryQueries = vehicleRepositoryQueries ?? throw new ArgumentNullException(nameof (vehicleRepositoryQueries));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<VehicleViewModel> Handle(AddOrderVehicleCommand request, CancellationToken cancellationToken)
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

                var orderRepo = this.orderRepositoryQueries.GetById(request.OrderId);
                if (orderRepo == null)
                { 
                    string menssage = $"El pedido {request.OrderId} no existe.";
                    this.logger.LogError(menssage);
                    throw new Exception(menssage);
                }

                vehicleData.AddOrder(orderRepo);

                repository.Update(vehicleData);

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

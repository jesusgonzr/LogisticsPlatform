using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class DeleteOrderVehicleCommandHandler : IRequestHandler<DeleteOrderVehicleCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IVehicleRepositoryQueries vehicleRepositoryQueries;
        private readonly ILogger<DeleteOrderVehicleCommandHandler> logger;

        public DeleteOrderVehicleCommandHandler(IMapper mapper, ILogger<DeleteOrderVehicleCommandHandler> logger,
            IVehicleRepository repository, IVehicleRepositoryQueries vehicleRepositoryQueries)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.vehicleRepositoryQueries = vehicleRepositoryQueries ?? throw new ArgumentNullException(nameof(vehicleRepositoryQueries));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<bool> Handle(DeleteOrderVehicleCommand request, CancellationToken cancellationToken)
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

                var order = vehicleData.Orders.Where(o => o.Id == request.OrderId).FirstOrDefault();
                if (order == null)
                {
                    string menssage = $"El producto {request.OrderId} no existe en este vehiculo.";
                    this.logger.LogError(menssage);
                    throw new Exception(menssage);
                }

                vehicleData.RemoveOrder(order);

                repository.Update(vehicleData);

                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error creating a product.", request);
                throw;
            }
        }
    }
}

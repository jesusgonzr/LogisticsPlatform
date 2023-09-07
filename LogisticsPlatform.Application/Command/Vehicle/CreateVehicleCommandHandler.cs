using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using LogisticsPlatform.Orders;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, VehicleViewModel>
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IOrderRepositoryQueries orderRepositoryQueries;
        private readonly ILogger<CreateVehicleCommandHandler> logger;

        public CreateVehicleCommandHandler(IMapper mapper, ILogger<CreateVehicleCommandHandler> logger,
            IVehicleRepository repository, IOrderRepositoryQueries orderRepositoryQueries)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.orderRepositoryQueries = orderRepositoryQueries ?? throw new ArgumentNullException(nameof(orderRepositoryQueries));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<VehicleViewModel> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
			try
			{
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var newData = new LogisticsPlatform.Vehicles.Vehicle();
                if (request.Orders != null && request.Orders.Count > 0)
                {
                    foreach (var order in request.Orders)
                    {
                        var orderRepo = this.orderRepositoryQueries.GetById(order.OrderId);
                        if (orderRepo != null)
                        {
                            newData.AddOrder(orderRepo);
                        }
                        else
                        {
                            string menssage = $"El pedido {order.OrderId} no existe.";
                            this.logger.LogError(menssage);
                            throw new Exception(menssage);
                        }
                    }
                }

                repository.Add(newData);

                return Task.FromResult<VehicleViewModel>(this.mapper.Map<VehicleViewModel>(newData));
            }
			catch (Exception ex)
			{
                this.logger.LogError(ex, "Error creating a product.", request);
                throw;
			}
        }
    }
}

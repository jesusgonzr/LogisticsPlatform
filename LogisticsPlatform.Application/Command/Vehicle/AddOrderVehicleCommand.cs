using LogisticsPlatform.Application.Models;
using MediatR;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class AddOrderVehicleCommand : IRequest<VehicleViewModel>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
    }
}

using LogisticsPlatform.Application.Models;
using MediatR;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class UpdateLocationVehicleCommand : IRequest<VehicleViewModel>
    {
        public Guid Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get;  set; }
    }
}

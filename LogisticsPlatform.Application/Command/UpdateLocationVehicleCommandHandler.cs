using LogisticsPlatform.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Command
{
    public class UpdateLocationVehicleCommandHandler : IRequestHandler<UpdateLocationVehicleCommand, VehicleViewModel>
    {
        public Task<VehicleViewModel> Handle(UpdateLocationVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using LogisticsPlatform.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Command
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, VehicleViewModel>
    {
        public Task<VehicleViewModel> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

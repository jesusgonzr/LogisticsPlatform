using LogisticsPlatform.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Command
{
    public class AddOrderVehicleCommandHandler : IRequestHandler<AddOrderVehicleCommand, VehicleViewModel>
    {
        public Task<VehicleViewModel> Handle(AddOrderVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

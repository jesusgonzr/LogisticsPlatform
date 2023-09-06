using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Command
{
    public class DeleteOrderVehicleCommandHandler : IRequestHandler<DeleteOrderVehicleCommand, bool>
    {
        public Task<bool> Handle(DeleteOrderVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

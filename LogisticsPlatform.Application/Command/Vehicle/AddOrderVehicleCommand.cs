using LogisticsPlatform.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Command.Vehicle
{
    public class AddOrderVehicleCommand : IRequest<VehicleViewModel>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
    }
}

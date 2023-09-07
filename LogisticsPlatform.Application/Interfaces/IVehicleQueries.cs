using LogisticsPlatform.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Interfaces
{
    public interface IVehicleQueries
    {
        IEnumerable<VehicleViewModel> GetAll();

        VehicleViewModel GetbyId(Guid id);

        IEnumerable<VehicleViewModel> GetByOrderId(Guid orderId);
    }
}

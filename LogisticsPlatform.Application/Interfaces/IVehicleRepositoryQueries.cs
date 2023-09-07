using LogisticsPlatform.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Interfaces
{
    public interface IVehicleRepositoryQueries
    {
        IEnumerable<Vehicle> GetAll();

        Vehicle GetbyId(Guid id);

        IEnumerable<Vehicle> GetByOrderId(Guid orderId);
    }
}

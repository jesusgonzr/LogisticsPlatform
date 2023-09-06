using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using LogisticsPlatform.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.Queries
{
    public class VehicleRepositoryQueries : IVehicleRepositoryQueries
    {
        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetByProduct(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}

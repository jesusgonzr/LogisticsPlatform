using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Queries
{
    public class VehicleQueries : IVehicleQueries
    {
        public IEnumerable<VehicleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleViewModel GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

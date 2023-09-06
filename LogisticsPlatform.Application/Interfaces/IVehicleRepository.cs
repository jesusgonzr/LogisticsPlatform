using LogisticsPlatform.Commons;
using LogisticsPlatform.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        void Add(Vehicle entity);

        void Update(Vehicle entity);

        void Delete(Vehicle entity);
    }
}

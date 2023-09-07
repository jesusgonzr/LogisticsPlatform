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
        private readonly LogisticsPlatformContext context;

        public VehicleRepositoryQueries(LogisticsPlatformContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return this.context.Vehicles.ToList();
        }

        public Vehicle GetbyId(Guid id)
        {
            return context.Vehicles.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Vehicle> GetByProduct(Guid productId)
        {
            return this.context.Vehicles.Where(c => c.OrdersItem.Where(c => c.Id == productId).Any()).ToList();
        }
    }
}

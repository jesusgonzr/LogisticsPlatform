using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using LogisticsPlatform.Vehicles;
using Microsoft.EntityFrameworkCore;
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
            var reuslt = this.context.Vehicles
                .Include(f => f.OrdersItem)
                .Include(f => f.Locations)
                .ToList();
            return reuslt;
        }

        public Vehicle GetbyId(Guid id)
        {
            return context.Vehicles
                .Include(f => f.OrdersItem)
                .Include(f => f.Locations)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Vehicle> GetByOrderId(Guid orderId)
        {
            return this.context.Vehicles
                .Include(f => f.OrdersItem)
                .Include(f => f.Locations)
                .Where(c => c.OrdersItem.Where(c => c.Id == orderId).Any()).ToList();
        }
    }
}

using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Vehicles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.Rpositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly LogisticsPlatformContext context;

        public VehicleRepository(LogisticsPlatformContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Vehicle entity)
        {
            this.context.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(Vehicle entity)
        {
            var result = this.context.Vehicles.Where(o => o.Id == entity.Id).FirstOrDefault();
            if (result != null)
            {
                _ = this.context.Vehicles.Remove(result);
                this.context.SaveChanges();
            }
        }

        public void Update(Vehicle entity)
        {
            var exist = this.context.Vehicles.Find(entity.Id);

            // Update main entity
            this.context.Entry(exist).CurrentValues.SetValues(entity);

            this.context.SaveChanges();
        }
    }
}

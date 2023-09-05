using LogisticsPlatform.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Vehicles
{
    public class Location : Entity
    {

        public Location(double latitude, double longitude)
            : this()
        {
            Id = Guid.NewGuid();
            this.Date = DateTime.Now;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        protected Location()
        {
        }

        public DateTime Date { get; protected set; }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }

        public Guid VehiculeId { get; protected set; }

        public Vehicle Vehicle { get; protected set; }
    }
}

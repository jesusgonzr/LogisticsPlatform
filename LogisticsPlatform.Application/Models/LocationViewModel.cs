using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Models
{
    public class LocationViewModel : BaseModelViewModel
    {
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

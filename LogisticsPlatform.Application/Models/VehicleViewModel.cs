using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Models
{
    public class VehicleViewModel : BaseModelViewModel
    {
        public List<LocationViewModel>? Locations { get; set; }
        public List<OrderViewModel>? Orders { get; set; }
    }
}

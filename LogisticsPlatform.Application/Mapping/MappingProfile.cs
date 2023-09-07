using AutoMapper;
using LogisticsPlatform.Application.Models;
using LogisticsPlatform.Orders;
using LogisticsPlatform.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Application.Mapping
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            _ = this.CreateMap<Vehicle, VehicleViewModel>();
            _ = this.CreateMap<VehicleViewModel, Vehicle>();

            _ = this.CreateMap<OrderViewModel, Order>();
            _ = this.CreateMap<Order, OrderViewModel>();

            _ = this.CreateMap<LocationViewModel, Location>();
            _ = this.CreateMap<Location, LocationViewModel>();
        }
    }
}

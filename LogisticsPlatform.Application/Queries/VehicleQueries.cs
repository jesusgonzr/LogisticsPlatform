using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogisticsPlatform.Application.Queries
{
    public class VehicleQueries : IVehicleQueries
    {
        private readonly IMapper mapper;
        private IVehicleRepositoryQueries query;

        public VehicleQueries(IVehicleRepositoryQueries query, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public IEnumerable<VehicleViewModel> GetAll()
        {
            return this.mapper.Map<IEnumerable<VehicleViewModel>>(this.query.GetAll());
        }

        public VehicleViewModel GetbyId(Guid id)
        {
            return this.mapper.Map<VehicleViewModel>(this.query.GetbyId(id));
        }

        public IEnumerable<VehicleViewModel> GetByOrderId(Guid orderId)
        {
            return this.mapper.Map<IEnumerable<VehicleViewModel>>(this.query.GetByOrderId(orderId));
        }
    }
}

using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;

namespace LogisticsPlatform.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly IMapper mapper;
        private IOrderRepositoryQueries queries;

        public OrderQueries(IOrderRepositoryQueries queries, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return this.mapper.Map<IEnumerable<OrderViewModel>>(this.queries.GetAll());
        }

        public OrderViewModel GetById(Guid id)
        {
            return this.mapper.Map<OrderViewModel>(this.queries.GetById(id));
        }
    }
}

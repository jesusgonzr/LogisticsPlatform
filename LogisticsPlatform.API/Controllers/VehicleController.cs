using AutoMapper;
using LogisticsPlatform.Application.Command.Vehicle;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Xml.Linq;

namespace LogisticsPlatform.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly ILogger<VehicleController> logger;
        private readonly IVehicleQueries queries;

        public VehicleController(IMediator mediator, IMapper mapper, ILogger<VehicleController> logger, IVehicleQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<VehicleViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            var result = this.queries.GetAll();
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(VehicleViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetById(Guid id)
        {
            var result = this.queries.GetbyId(id);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpGet("productId")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(VehicleViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetByProductId(Guid productId)
        {
            var result = this.queries.GetByProduct(productId);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(VehicleViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateVehicleCommand command)
        {
            if (command == null)
            {
                return this.UnprocessableEntity();
            }

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }

        [HttpPut]
        [ProducesResponseType(typeof(VehicleViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationVehicleCommand command)
        {
            if (command == null)
            {
                return this.UnprocessableEntity();
            }

            var result = this.queries.GetbyId(command.Id);
            if (result == null)
            {
                return this.NotFound();
            }

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }

        [HttpPut]
        [ProducesResponseType(typeof(VehicleViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderVehicleCommand command)
        {
            if (command == null)
            {
                return this.UnprocessableEntity();
            }

            var result = this.queries.GetbyId(command.Id);
            if (result == null)
            {
                return this.NotFound();
            }

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderVehicleCommand command)
        {
            if (command == null)
            {
                return this.UnprocessableEntity();
            }

            var result = this.queries.GetbyId(command.Id);
            if (result == null)
            {
                return this.NotFound();
            }

            var commandResult = await this.mediator.Send(command);

            return this.Ok(commandResult);
        }
    }
}

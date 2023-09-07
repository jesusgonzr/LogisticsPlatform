using AutoMapper;
using LogisticsPlatform.Application.Interfaces;
using LogisticsPlatform.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LogisticsPlatform.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> logger;
        private readonly IOrderQueries queries;

        public OrderController(ILogger<OrderController> logger, IOrderQueries queries)
        {
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
    }
}

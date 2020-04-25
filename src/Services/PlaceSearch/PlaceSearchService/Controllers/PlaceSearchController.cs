using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaceSearchService.Api.Queries;

namespace PlaceSearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceSearchController : ControllerBase
    {
        private readonly ILogger<PlaceSearchController> logger;
        private readonly IMediator mediator;

        public PlaceSearchController(ILogger<PlaceSearchController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(FindPlaceQueryResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Search([FromQuery] FindPlaceQuery findQuery)
        {
            var result = await mediator.Send(findQuery);
            return Ok(result);
        }
    }
}

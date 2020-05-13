using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlaceSearchService.Api.Queries;

namespace PlaceSearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceSearchController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlaceSearchController(IMediator mediator)
        {
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PlaceSearchService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceSearchController : ControllerBase
    {
        private readonly ILogger<PlaceSearchController> logger;

        public PlaceSearchController(ILogger<PlaceSearchController> logger)
        {
            this.logger = logger;
        }
    }
}

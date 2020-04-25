using System.Collections.Generic;
using PlaceSearchService.Api.Queries.Dtos.Place;

namespace PlaceSearchService.Api.Queries
{
    public class FindPlaceQueryResult
    {
        public List<PlaceDto> Places { get; set; }
    }
}

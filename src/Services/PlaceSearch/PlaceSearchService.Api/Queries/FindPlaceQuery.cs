using MediatR;

namespace PlaceSearchService.Api.Queries
{
    public class FindPlaceQuery : IRequest<FindPlaceQueryResult>
    {
        public string Name { get; set; }
    }
}

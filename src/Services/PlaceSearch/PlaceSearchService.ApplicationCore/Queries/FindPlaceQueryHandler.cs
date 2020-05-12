using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlaceSearchService.Api.Queries;
using PlaceSearchService.Api.Queries.Dtos.Place;

namespace PlaceSearchService.ApplicationCore.Queries
{
    public class FindPlaceQueryHandler : IRequestHandler<FindPlaceQuery, FindPlaceQueryResult>
    {
        public Task<FindPlaceQueryResult> Handle(FindPlaceQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FindPlaceQueryResult()
            {
                Places = new List<PlaceDto>
                {
                    new PlaceDto
                    {
                        Name = "test name"
                    }
                }
            });
        }
    }
}

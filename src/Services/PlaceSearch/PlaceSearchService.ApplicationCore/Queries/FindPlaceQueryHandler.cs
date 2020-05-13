using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlaceSearchService.Api.Queries;
using PlaceSearchService.Api.Queries.Dtos.Place;
using PlaceSearchService.Domain.Repositories;

namespace PlaceSearchService.ApplicationCore.Queries
{
    public class FindPlaceQueryHandler : IRequestHandler<FindPlaceQuery, FindPlaceQueryResult>
    {
        private readonly IPlaceReadRepository placeReadRepository;

        public FindPlaceQueryHandler(IPlaceReadRepository placeReadRepository)
        {
            this.placeReadRepository = placeReadRepository;
        }

        public async Task<FindPlaceQueryResult> Handle(FindPlaceQuery request, CancellationToken cancellationToken)
        {
            var result = await placeReadRepository.Find(request.Name);

            return new FindPlaceQueryResult
            {
                Places = result.Select(x => new PlaceDto
                {
                    Name = x.Name
                }).ToList()
            };
        }
    }
}

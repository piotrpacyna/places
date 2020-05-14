using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaceSearchService.Domain.Place;
using PlaceSearchService.Domain.Repositories;
using PlaceSearchService.Infrastructure.DataAccess.ElasticSearch;

namespace PlaceSearchService.Infrastructure.Repositories.ElasticSearch
{
    public class PlaceReadRepository : IPlaceReadRepository
    {
        private readonly PlaceElasticSearchClient elasticClient;

        public PlaceReadRepository(PlaceElasticSearchClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task<List<Place>> Find(string name)
        {
            var result = await elasticClient.Client.SearchAsync<Place>(s => s
                .Size(25)
                .Query(q => q
                    .Match(m => m
                        .Field(p => p.Name)
                        .Query(name)
                    )
                )
            );
            return result.Documents.ToList();
        }
    }
}

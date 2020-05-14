using Microsoft.Extensions.Configuration;
using Nest;
using PlaceSearchService.Domain.Place;

namespace PlaceSearchService.Infrastructure.DataAccess.ElasticSearch
{
    public class PlaceElasticSearchClient : ElasticSearchClient
    {
        public PlaceElasticSearchClient(IConfiguration configuration) : base(configuration["ElasticSearch:Place:Url"], configuration["ElasticSearch:Place:Index"])
        {
        }

        protected override IResponse CreateIndex()
        {
            var response = Client.Indices.Create(DefaultIndexName, i => i
                .Map<Place>(m => m
                    .AutoMap()
                )
            );

            return response;
        }
    }
}

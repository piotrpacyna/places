using System;
using Autofac;
using Nest;

namespace PlaceSearchService.Infrastructure.DataAccess.ElasticSearch
{
    public abstract class ElasticSearchClient : IStartable
    {
        private readonly string url;

        public string DefaultIndexName { get; }
        public IElasticClient Client { get; }

        protected ElasticSearchClient(string url, string indexName)
        {
            this.url = url;
            DefaultIndexName = indexName;
            Client = Create();
        }

        public void Start()
        {
            if (IndexExist())
            {
                return;
            }

            var response = CreateIndex();

            if (!response.IsValid)
            {
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);
            }
        }

        protected abstract IResponse CreateIndex();

        protected bool IndexExist()
        {
            return Client.Indices.Exists(DefaultIndexName).Exists;
        }

        private ElasticClient Create()
        {
            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(DefaultIndexName)
                .EnableDebugMode()
                .DisableDirectStreaming()
                .PrettyJson();

            return new ElasticClient(settings);
        }
    }
}

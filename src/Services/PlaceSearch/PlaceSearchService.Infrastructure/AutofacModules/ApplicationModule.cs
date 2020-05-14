using Autofac;
using PlaceSearchService.Domain.Repositories;
using PlaceSearchService.Infrastructure.DataAccess.ElasticSearch;
using PlaceSearchService.Infrastructure.Repositories.ElasticSearch;

namespace PlaceSearchService.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlaceElasticSearchClient>()
                .AsSelf()
                .As<IStartable>()
                .SingleInstance();

            builder.RegisterType<PlaceReadRepository>()
                .As<IPlaceReadRepository>()
                .InstancePerLifetimeScope();
        }
    }
}

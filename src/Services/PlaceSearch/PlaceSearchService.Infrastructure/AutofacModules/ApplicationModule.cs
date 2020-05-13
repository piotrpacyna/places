using Autofac;
using PlaceSearchService.Domain.Repositories;
using PlaceSearchService.Infrastructure.Repositories.Fake;

namespace PlaceSearchService.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakePlaceReadRepository>()
                .As<IPlaceReadRepository>()
                .InstancePerLifetimeScope();
        }
    }
}

using System.Reflection;
using Autofac;
using FluentValidation;
using MediatR;
using PlaceSearchService.Api.Queries;
using PlaceSearchService.ApplicationCore.PipelineBehaviors;
using PlaceSearchService.ApplicationCore.Queries;

namespace PlaceSearchService.Infrastructure.AutofacModules
{
    public class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IValidator<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder.RegisterAssemblyTypes(typeof(FindPlaceQuery).GetTypeInfo().Assembly, typeof(FindPlaceQueryHandler).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => componentContext.TryResolve(t, out var o) ? o : null;
            });

            builder.RegisterGeneric(typeof(TracePipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}

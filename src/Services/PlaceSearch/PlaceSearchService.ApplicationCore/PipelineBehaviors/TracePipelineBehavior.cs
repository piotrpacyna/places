using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace PlaceSearchService.ApplicationCore.PipelineBehaviors
{
    public class TracePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TracePipelineBehavior<TRequest, TResponse>> logger;

        public TracePipelineBehavior(ILogger<TracePipelineBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            logger.LogInformation($"Executing handler for {typeof(TRequest).FullName}");
            var response = await next();
            logger.LogInformation($"Executed handler for {typeof(TRequest).FullName}");
            return response;
        }
    }
}

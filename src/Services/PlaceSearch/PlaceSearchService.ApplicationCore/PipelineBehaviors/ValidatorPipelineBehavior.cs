using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using PlaceSearchService.ApplicationCore.Exceptions;

namespace PlaceSearchService.ApplicationCore.PipelineBehaviors
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] validators;
        private readonly ILogger<ValidatorPipelineBehavior<TRequest, TResponse>> logger;

        public ValidatorPipelineBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorPipelineBehavior<TRequest, TResponse>> logger)
        {
            this.validators = validators;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                logger.LogWarning($"Command Validation Errors for type {typeof(TRequest).Name} with Failures: {string.Join(Environment.NewLine, failures.Select(x => x.ErrorMessage).ToList())}");
                throw new CommandValidationException($"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
            }

            return await next();
        }
    }
}

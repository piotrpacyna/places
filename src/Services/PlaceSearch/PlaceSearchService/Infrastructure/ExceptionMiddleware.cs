using System;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PlaceSearchService.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            string message;

            switch (ex)
            {
                case ValidationException exception:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    message = exception.Message;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    message = ex.Message;
                    break;
            }

            if (context.Response.StatusCode >= 500)
            {
                logger.LogError(ex, ex.Message);
            }
            else
            {
                logger.LogDebug(ex, ex.Message);
            }

            var result = JsonSerializer.Serialize(new { error = message });
            await context.Response.WriteAsync(result);
        }
    }
}

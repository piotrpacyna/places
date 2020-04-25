using Microsoft.AspNetCore.Builder;

namespace PlaceSearchService.Infrastructure
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<ExceptionMiddleware>();
    }
}

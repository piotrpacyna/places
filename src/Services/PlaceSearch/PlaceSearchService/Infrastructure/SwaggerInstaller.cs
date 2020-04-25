using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PlaceSearchService.Infrastructure
{
    public static class SwaggerInstaller
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Place Search API", 
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Piotr Pacyna",
                        Email = "piotr@pacyna.dev"
                    }
                });
            });

            return services;
        }

        public static void UseCustomSwagger(this IApplicationBuilder builder)
            => builder.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("../swagger/v1/swagger.json", "Place Search API V1");
                });
    }
}

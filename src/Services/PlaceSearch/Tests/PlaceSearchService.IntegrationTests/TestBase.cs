using System.IO;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace PlaceSearchService.IntegrationTests
{
    public class TestBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetExecutingAssembly()
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", false, true);
                })
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>();

            var testServer = new TestServer(hostBuilder);
            return testServer;
        }
    }
}

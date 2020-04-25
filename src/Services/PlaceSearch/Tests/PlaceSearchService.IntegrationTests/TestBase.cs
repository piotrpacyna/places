using System.IO;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace PlaceSearchService.IntegrationTests
{
    public class TestBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(PlaceSearchServiceTests))
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>();

            var testServer = new TestServer(hostBuilder);
            return testServer;
        }
    }
}

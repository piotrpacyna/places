using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PlaceSearchService.IntegrationTests
{
    public class PlaceSearchServiceTests : TestBase
    {
        [Fact]
        public async Task Search_WhenQueryStringParametersAreNotProvided_ShouldReturnBadRequestStatusCode()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(PlaceSearchServiceUrls.Get.Search);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Search_WhenNameIsEmpty_ShouldReturnBadRequestStatusCode()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(PlaceSearchServiceUrls.Get.SearchByName(string.Empty));

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Search_WhenNameIsFilled_ShouldReturnOkStatusCode()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(PlaceSearchServiceUrls.Get.SearchByName("test"));

                response.EnsureSuccessStatusCode();
            }
        }
    }
}

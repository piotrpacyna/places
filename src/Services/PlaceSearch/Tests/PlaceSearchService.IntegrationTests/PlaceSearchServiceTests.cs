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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Search_WhenNameIsEmpty_ShouldReturnBadRequestStatusCode(string name)
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(PlaceSearchServiceUrls.Get.SearchByName(name));

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

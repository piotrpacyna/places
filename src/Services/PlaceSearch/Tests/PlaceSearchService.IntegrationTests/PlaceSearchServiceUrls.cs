namespace PlaceSearchService.IntegrationTests
{
    public static class PlaceSearchServiceUrls
    {
        public static class Get
        {
            private const string BaseUrl = "api/placesearch";

            public static readonly string Search = $"{BaseUrl}/search";

            public static string SearchByName(string name)
            {
                return $"{Search}?name={name}";
            }
        }
    }
}

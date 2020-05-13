namespace PlaceSearchService.Domain.Place
{
    public class Place
    {
        public string Name { get; private set; }

        public Place(string name)
        {
            Name = name;
        }
    }
}

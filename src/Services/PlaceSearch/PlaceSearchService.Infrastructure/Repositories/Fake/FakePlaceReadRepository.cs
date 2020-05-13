using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaceSearchService.Domain.Place;
using PlaceSearchService.Domain.Repositories;

namespace PlaceSearchService.Infrastructure.Repositories.Fake
{
    public class FakePlaceReadRepository : IPlaceReadRepository
    {
        private readonly List<Place> fakePlaces = new List<Place>
        {
            new Place("Szczecin"),
            new Place("Warszawa"),
            new Place("Katowice"),
            new Place("Kalisz")
        };

        public Task<List<Place>> Find(string name)
        {
            return Task.FromResult(fakePlaces.Where(x => x.Name.Contains(name)).ToList());
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceSearchService.Domain.Repositories
{
    public interface IPlaceReadRepository
    {
        Task<List<Place.Place>> Find(string name);
    }
}

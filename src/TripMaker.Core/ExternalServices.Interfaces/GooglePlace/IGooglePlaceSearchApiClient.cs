using Abp.Application.Services;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceSearchApiClient : IApplicationService
    {
        Task<GooglePlaceSearchRootObject> GetAllAsync(string input);

        Task<GooglePlaceSearchRootObject> GetAllAsync(string input, Location location);

        Task<GooglePlaceSearchRootObject> GetAllAsync(string input, Location location, int radius);
    }
}

using Abp.Application.Services;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GoogleDirections;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleDirectionsApiClient : IApplicationService
    {
        Task<GoogleDirectionsRootObject> GetAllAsync(Location origin, Location destination);

        Task<GoogleDirectionsRootObject> GetAllAsync(string originPlaceId, string destinationPlaceId);
    }
}

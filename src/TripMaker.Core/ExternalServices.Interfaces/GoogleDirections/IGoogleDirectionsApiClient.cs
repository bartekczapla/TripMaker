using Abp.Application.Services;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GoogleDirections;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleDirectionsApiClient : IApplicationService
    {
        Task<GoogleDirectionsRootObject> GetAsync(GoogleDirectionsInput input);
    }
}

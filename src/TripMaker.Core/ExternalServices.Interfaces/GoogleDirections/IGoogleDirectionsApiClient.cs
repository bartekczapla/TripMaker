using Abp.Application.Services;
using Abp.Domain.Services;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GoogleDirections;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleDirectionsApiClient : IDomainService
    {
        Task<GoogleDirectionsRootObject> GetAsync(GoogleDirectionsInput input);
    }
}

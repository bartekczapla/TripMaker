using Abp.Application.Services;
using Abp.Domain.Services;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceSearchApiClient : IDomainService
    {
        Task<GooglePlaceSearchRootObject> GetAsync(GooglePlaceSearchInput input);
    }
}

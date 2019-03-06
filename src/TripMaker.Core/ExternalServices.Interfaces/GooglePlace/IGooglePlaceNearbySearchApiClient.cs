
using Abp.Application.Services;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;


namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceNearbySearchApiClient : IDomainService
    {
        Task<GooglePlaceNearbySearchRootObject> GetAsync(GooglePlaceNearbySearchInput input);

        Task<GooglePlaceNearbySearchRootObject> GetNextPageTokenAsync(string token);
    }
}

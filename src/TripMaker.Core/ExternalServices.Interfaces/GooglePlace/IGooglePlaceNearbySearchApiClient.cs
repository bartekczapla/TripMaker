
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;


namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceNearbySearchApiClient : IApplicationService
    {
        Task<GooglePlaceNearbySearchRootObject> GetAllAsync(Location location, int radius);

        Task<GooglePlaceNearbySearchRootObject> GetNextPageTokenAsync(string token);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Helpers;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan.Interfaces;

namespace TripMaker.Plan
{

    public class PlanDataProvider : IPlanDataProvider
    {
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceSearchApiClient _googlePlaceSearchApiClient;
        private readonly IGooglePlaceNearbySearchApiClient _googlePlaceNearbySearchApiClient;
        private readonly IGooglePlacePhotosApiCaller _googlePlacePhotosApiCaller;


        public PlanDataProvider(
            IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient,
            IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller
            )
        {
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceSearchApiClient = googlePlaceSearchApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;

        }

        public async Task<bool> IsPlaceIdValid(string placeId)
        {
            var result=await _googlePlaceDetailsApiClient.GetMinimumAsync(placeId);
            return InterpreteGoogleStatus.IsStatusOk(result.status);
        }

        public Task<IEnumerable<PlanElement>> ProvideDataAsync(PlanForm planForm)
        {
            throw new NotImplementedException();
        }
    }
}

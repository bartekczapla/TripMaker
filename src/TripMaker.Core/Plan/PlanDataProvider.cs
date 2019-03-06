using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.ExternalServices.Helpers;
using TripMaker.ExternalServices.Interfaces;
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
        private readonly IGoogleDirectionsApiClient _googleDirectionsApiClient;

        public PlanDataProvider(
            IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient,
            IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller,
            IGoogleDirectionsApiClient googleDirectionsApiClient
            )
        {
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceSearchApiClient = googlePlaceSearchApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;
            _googleDirectionsApiClient = googleDirectionsApiClient;

        }

        //public async Task<bool> IsPlaceIdValid(string placeId)
        //{
        //    var result=await _googlePlaceDetailsApiClient.GetAsync(new GooglePlaceDetailsInput(placeId,Enums.LanguageType.Pl));
        //    return InterpreteGoogleStatus.IsStatusOk(result.status);
        //}

        public async Task ProvideDataAsync(PlanForm planForm)
        {
            var googleDetailsInput = new GooglePlaceDetailsInput(planForm.PlaceId, planForm.Language);
            googleDetailsInput.Fields.Add(new GoogleField("geometry", GoogleFieldType.Address, new ExternalServicesType[] { ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails }));

            var googleDetails = await _googlePlaceDetailsApiClient.GetAsync(googleDetailsInput);

            var googlePlaceSearch = new GooglePlaceSearchInput("restauracja", googleDetails.Result.geometry.location, planForm.Language, 3000);
            var googleSearch = await _googlePlaceSearchApiClient.GetAsync(googlePlaceSearch);

            var googleNearbyInput = new GooglePlaceNearbySearchInput(googleDetails.Result.geometry.location, planForm.Language, "restaurant", new GooglePlaceType(), 0, 2);
            var googleNearby = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);

            var googleDirectionsInput = new GoogleDirectionsInput(googleNearby.results[0].geometry.location, googleNearby.results[2].geometry.location, GoogleTravelMode.Walking, planForm.Language);
            var googleDirections = await _googleDirectionsApiClient.GetAsync(googleDirectionsInput);

            Console.Write("Test");
        }
    }
}

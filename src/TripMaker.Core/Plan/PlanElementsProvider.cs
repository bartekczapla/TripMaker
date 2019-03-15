using Abp.Events.Bus;
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

    public class PlanElementsProvider : IPlanElementsProvider
    {
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceSearchApiClient _googlePlaceSearchApiClient;
        private readonly IGooglePlaceNearbySearchApiClient _googlePlaceNearbySearchApiClient;
        private readonly IGooglePlacePhotosApiCaller _googlePlacePhotosApiCaller;
        private readonly IGoogleDirectionsApiClient _googleDirectionsApiClient;

        private readonly IGoogleDirectionsInputFactory _googleDirectionsInputFactory;
        private readonly IGoogleDistanceMatrixInputFactory _googleDistanceMatrixInputFactory;
        private readonly IGooglePlaceDetailsInputFactory _googlePlaceDetailsInputFactory;
        private readonly IGooglePlaceNearbySearchInputFactory _googlePlaceNearbySearchInputFactory;
        private readonly IGooglePlaceSearchInputFactory _googlePlaceSearchInputFactory;

        public IEventBus EventBus { get; set; }

        public PlanElementsProvider( IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient, IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller,
            IGoogleDirectionsApiClient googleDirectionsApiClient,
            IGoogleDirectionsInputFactory googleDirectionsInputFactory, IGoogleDistanceMatrixInputFactory googleDistanceMatrixInputFactory,
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory, IGooglePlaceNearbySearchInputFactory googlePlaceNearbySearchInputFactory,
            IGooglePlaceSearchInputFactory googlePlaceSearchInputFactory)
        {
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceSearchApiClient = googlePlaceSearchApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;
            _googleDirectionsApiClient = googleDirectionsApiClient;

            _googleDirectionsInputFactory = googleDirectionsInputFactory;
            _googleDistanceMatrixInputFactory = googleDistanceMatrixInputFactory;
            _googlePlaceDetailsInputFactory = googlePlaceDetailsInputFactory;
            _googlePlaceNearbySearchInputFactory = googlePlaceNearbySearchInputFactory;
            _googlePlaceSearchInputFactory = googlePlaceSearchInputFactory;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Plan> GenerateAsync(PlanForm planForm)
        {
            var plan = new Plan(planForm.PlaceName, planForm.Id);

            var destinationInfo = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAll(planForm.PlaceId, planForm.Language));

            var googleNearbyRestaurantInput = _googlePlaceNearbySearchInputFactory.Create(destinationInfo.Result.geometry.location, planForm.Language, new GooglePlaceType("bar", GooglePlaceTypeCategory.None));
            var nearbyRestaurant = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyRestaurantInput);

            var firstMatch = nearbyRestaurant.results.First();

            var planElement = new PlanElement(firstMatch.name, firstMatch.place_id, firstMatch.geometry.location.lat,  firstMatch.geometry.location.lng, 1, planForm.StartDate.Add(planForm.StartTime.Value), planForm.StartDate.Add(planForm.StartTime.Value.Add(new TimeSpan(1,0,0))), PlanElementType.Partying, null);

            plan.Elements.Add(planElement);



            return plan;
        }
    }
}

            //var googleDetailsInput = new GooglePlaceDetailsInput(planForm.PlaceId, planForm.Language);
            // googleDetailsInput.Fields.Add(new GoogleField("geometry", GoogleFieldType.Address, new ExternalServicesType[] { ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails }));

            //var googleDetails = await _googlePlaceDetailsApiClient.GetAsync(googleDetailsInput);

            //var googlePlaceSearch = new GooglePlaceSearchInput("restauracja", googleDetails.Result.geometry.location, planForm.Language, 3000);
            //var googleSearch = await _googlePlaceSearchApiClient.GetAsync(googlePlaceSearch);

            //var googleNearbyInput = new GooglePlaceNearbySearchInput(googleDetails.Result.geometry.location, planForm.Language, "restaurant", new GooglePlaceType(), 0, 2);
            //var googleNearby = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);

            //var googleDirectionsInput = new GoogleDirectionsInput(googleNearby.results[0].geometry.location, googleNearby.results[2].geometry.location, GoogleTravelMode.Walking, planForm.Language);
            //var googleDirections = await _googleDirectionsApiClient.GetAsync(googleDirectionsInput);
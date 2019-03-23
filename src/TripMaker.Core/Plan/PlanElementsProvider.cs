using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.Common;
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

    public class PlanElementsProvider : PlanElementsAssumptions, IPlanElementsProvider
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

            //Destination Info
            var destinationInfo = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAllUseful(planForm.PlaceId, planForm.Language));

            //Accomodation
            var accomodation = new Accomodation(destinationInfo.Result.geometry.location , destinationInfo.Result.place_id);

            //TEST
             var googleNearbyRestaurantInput = _googlePlaceNearbySearchInputFactory.Create(accomodation.Location, planForm.Language, GooglePlaceTypeCategory.Culture);
             var nearbyResult= await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyRestaurantInput);
             var firstMatch = nearbyResult.results.First();

            //Time iterator
            var currentDateTime = planForm.StartTime.HasValue ? planForm.StartDate.Add(planForm.StartTime.Value) : planForm.StartDate.Add(StartTimeAssumption);
            //End time
            var endDateTime = planForm.EndTime.HasValue ? planForm.EndDate.Add(planForm.EndTime.Value) : planForm.StartDate.Add(EndTimeAssumption);

            IList<PlanElement> CurrentDayElements = new List<PlanElement>();
            int iter = 1;
            //while (DateTime.Compare(currentDateTime, endDateTime) >= 0)
            //{
                var start = new PlanElement("start", accomodation.PlaceId, accomodation.Location.lat, accomodation.Location.lng, iter, currentDateTime, currentDateTime.Add(OneHour), PlanElementType.Sleeping, null);
                plan.Elements.Add(start);

                iter += 1;
                var planElement = new PlanElement(firstMatch.name, firstMatch.place_id, firstMatch.geometry.location.lat,  firstMatch.geometry.location.lng, 1, planForm.StartDate.Add(planForm.StartTime.Value), planForm.StartDate.Add(planForm.StartTime.Value.Add(new TimeSpan(1,0,0))), PlanElementType.Partying, null);            
                plan.Elements.Add(planElement);
                //CurrentDayElements.Add(planElement);
                

            //    if(planElement.ElementType == PlanElementType.Sleeping)
            //    {
            //        CurrentDayElements.Clear();
            //    }
            //}


            return plan;
        }

        static PlanElementType ProvideElementType(DateTime currentDateTime, IList<PlanElement> currentDayElements)
        {
            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Eating))
                return PlanElementType.Eating; //first thing- breakfast
            else
                return PlanElementType.Nothing;

        }
    }
}

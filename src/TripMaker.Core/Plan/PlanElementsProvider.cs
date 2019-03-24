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
using TripMaker.Plan.Models;

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
            var destinationInfo = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateBasic(planForm.PlaceId, planForm.Language));

            //Accomodation
            var accomodation = new Accomodation(destinationInfo.Result.geometry.location , destinationInfo.Result.place_id, destinationInfo.Result.name, destinationInfo.Result.formatted_address);



            //Time iterator
            var currentDateTime = planForm.StartTime.HasValue ? planForm.StartDate.Add(planForm.StartTime.Value) : planForm.StartDate.Add(StartTimeAssumption);
            //End time
            var endDateTime = planForm.EndTime.HasValue ? planForm.EndDate.Add(planForm.EndTime.Value) : planForm.StartDate.Add(EndTimeAssumption);

            //List to hold PlanElements from current day
            IList<PlanElement> CurrentDayElements = new List<PlanElement>();

            //PlanElements iter
            int iter = 1;

            //StartElement
            var startElement = new PlanElement(accomodation.FormattedAddress, accomodation.PlaceId, accomodation.Location.lat, accomodation.Location.lng, iter, currentDateTime, currentDateTime, PlanElementType.Moving, null);
            plan.Elements.Add(startElement);

            //previous PlanElemnt which hold previous Location for DirectionApi
            Location previousPlanElementLocation = Location.Create(startElement.Lat, startElement.Lng);

            while (DateTime.Compare(currentDateTime, endDateTime) >= 0)
            {
                iter += 1;

                //decide what to do
                var googleNearbyRestaurantInput = _googlePlaceNearbySearchInputFactory.Create(previousPlanElementLocation, planForm.Language, GooglePlaceTypeCategory.Culture);
                var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyRestaurantInput);
                var firstMatch = nearbyResult.results.First();



                //create planElement
                var planElement = new PlanElement(firstMatch.name, firstMatch.place_id, 
                                                firstMatch.geometry.location.lat,  firstMatch.geometry.location.lng, 
                                                iter, planForm.StartDate.Add(planForm.StartTime.Value), planForm.StartDate.Add(planForm.StartTime.Value.Add(new TimeSpan(1,0,0))), 
                                                PlanElementType.Partying, null);

                //travelMode
                var travelMode = GoogleTravelMode.Walking;

                //directions between previous and next place
                var directionsApiInput = _googleDirectionsInputFactory.Create(previousPlanElementLocation, Location.Create(planElement.Lat, planElement.Lng), planForm.Language, travelMode);
                var directionsApiResult = await _googleDirectionsApiClient.GetAsync(directionsApiInput);

                if(InterpreteGoogleStatus.IsStatusOk(directionsApiResult.status) && directionsApiResult.routes.Any() && directionsApiResult.routes.FirstOrDefault().legs.Any())
                {
                    var route = directionsApiResult.routes.First().legs.First(); //only 1 leg if no waypoints
                    var planRoute = new PlanRoute(route.distance.value, route.duration.value);

                    //update planElement time

                    //steps of route
                    foreach(var step in route.steps)
                    {
                        planRoute.Steps.Add(new PlanRouteStep(step.distance.value, step.duration.value, 
                                                            step.start_location.lat, step.start_location.lng,
                                                          step.end_location.lat, step.end_location.lng, 
                                                          InterpreteEnums.InterpreteTravelMode(step.travel_mode), 
                                                          step.html_instructions, step.maneuver));
                    }

                    planElement.EndingRoute = planRoute;
                }

                //add to Plan and CurrentDayElements lists
                plan.Elements.Add(planElement);
                CurrentDayElements.Add(planElement);

                //change previous Location
                previousPlanElementLocation.lat = planElement.Lat;
                previousPlanElementLocation.lng = planElement.Lng;

                if (planElement.ElementType == PlanElementType.Sleeping)
                {
                    CurrentDayElements.Clear();
                }
            }

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

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

        private readonly IPlanElementDecisionMaker _planElementDecisionMaker;
        private readonly IPlanElementCandidateFactory _planElementCandidateFactory;
        private readonly IPlanElementByUserPreferencesPicker _planElementByUserPreferencesPicker;

        public IEventBus EventBus { get; set; }

        public PlanElementsProvider( IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient, IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller,
            IGoogleDirectionsApiClient googleDirectionsApiClient,
            IGoogleDirectionsInputFactory googleDirectionsInputFactory, IGoogleDistanceMatrixInputFactory googleDistanceMatrixInputFactory,
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory, IGooglePlaceNearbySearchInputFactory googlePlaceNearbySearchInputFactory,
            IGooglePlaceSearchInputFactory googlePlaceSearchInputFactory, IPlanElementCandidateFactory planElementCandidateFactory,
            IPlanElementDecisionMaker planElementDecisionMaker, IPlanElementByUserPreferencesPicker planElementByUserPreferencesPicker)
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

            _planElementDecisionMaker = planElementDecisionMaker;
            _planElementCandidateFactory = planElementCandidateFactory;
            _planElementByUserPreferencesPicker = planElementByUserPreferencesPicker;

            EventBus = NullEventBus.Instance;
        }

        public async Task<IList<PlanElement>> GenerateAsync(DecisionArray decisionArray, Plan plan)
        {
            var elements = new List<PlanElement>();

            int ElementIter = 1;
            Location previousPlanElementLocation = Location.Create(plan.StartLocation.lat, plan.StartLocation.lng);

            foreach(var row in decisionArray.DecisionRows)
            {
                elements.Add(PlanElement.Create(row, ElementIter));
                ++ElementIter;
            }

            //while(DateTime.Compare(plan.PlanForm.StartDateTime, plan.PlanForm.EndDateTime) <= 0)
            //{

            //}

            return elements;
        }

        //public async Task<Plan> GenerateAsync(PlanForm planForm)
        //{

        //    while (DateTime.Compare(currentDateTime, endDateTime) <= 0)
        //    {
        //        iter += 1;

        //        //declare local variables 
        //        var planElement = new PlanElement(iter, currentDateTime, currentDateTime);

        //        //decide what to do
        //        var decision = _planElementDecisionMaker.Decide(currentDateTime, CurrentDayElements);



        //        //Get Plan Element
        //        if (decision.ElementType == PlanElementType.Sleeping)
        //        {
        //            var candidate = PlanElementCandidate.First(x => x.ElementType == decision.ElementType);
        //            planElement.UpdateInformation(candidate.PlaceName, candidate.PlaceId, candidate.Location.lat, candidate.Location.lng, candidate.Duration, candidate.ElementType, candidate.Rating);
        //        }
        //        else if (decision.ElementType == PlanElementType.Eating || decision.ElementType == PlanElementType.Entertainment || decision.ElementType == PlanElementType.Relax ||
        //        decision.ElementType == PlanElementType.Activity || decision.ElementType == PlanElementType.Culture || decision.ElementType == PlanElementType.Sightseeing ||
        //        decision.ElementType == PlanElementType.Partying || decision.ElementType == PlanElementType.Shopping)
        //        {
        //            var candidate = _planElementByUserPreferencesPicker.Pick(PlanElementCandidate, decision.ElementType);
        //            planElement.UpdateInformation(candidate.PlaceName, candidate.PlaceId, candidate.Location.lat, candidate.Location.lng, candidate.Duration, candidate.ElementType, candidate.Rating);

        //            //update both lists
        //            UsedPlanElementCandidate.Add(candidate);
        //            PlanElementCandidate.RemoveAll(x => x.PlaceId == candidate.PlaceId && x.PlaceName == candidate.PlaceName);

        //        }
        //        else //nothing
        //        {
        //            var candidate = _planElementByUserPreferencesPicker.Pick(PlanElementCandidate, PlanElementType.Nothing);
        //            planElement.UpdateInformation(candidate.PlaceName, candidate.PlaceId, candidate.Location.lat, candidate.Location.lng, candidate.Duration, candidate.ElementType, candidate.Rating);

        //        }

        //        //-----------------------------//
        //        //---- DIRECTIONS ------------//

        //        //travelMode
        //        var travelMode = GoogleTravelMode.Walking;

        //        //directions between previous and next place
        //        var directionsApiInput = _googleDirectionsInputFactory.Create(previousPlanElementLocation, Location.Create(planElement.Lat, planElement.Lng), planForm.Language, travelMode);
        //        var directionsApiResult = await _googleDirectionsApiClient.GetAsync(directionsApiInput);

        //        if (InterpreteGoogleStatus.IsStatusOk(directionsApiResult.status) && directionsApiResult.routes.Any() && directionsApiResult.routes.FirstOrDefault().legs.Any())
        //        {
        //            var route = directionsApiResult.routes.First().legs.First(); //only 1 leg if no waypoints
        //            var planRoute = new PlanRoute(route.distance.value, route.duration.value);

        //            //update planElement time with time take by route
        //            var routeDuration = TimeSpan.FromSeconds(route.duration.value);
        //            planElement.UpdateDateTimeWithRouteDuration(routeDuration);

        //            //steps of route
        //            foreach (var step in route.steps)
        //            {
        //                planRoute.Steps.Add(new PlanRouteStep(step.distance.value, step.duration.value,
        //                                                    step.start_location.lat, step.start_location.lng,
        //                                                  step.end_location.lat, step.end_location.lng,
        //                                                  InterpreteEnums.InterpreteTravelMode(step.travel_mode),
        //                                                  step.html_instructions, step.maneuver));
        //            }

        //            planElement.EndingRoute = planRoute;
        //        }
        //        else
        //        {
        //            var planRoute = new PlanRoute(0, 0);
        //            planElement.EndingRoute = planRoute;
        //        }

        //        //add to Plan and CurrentDayElements lists
        //        plan.Elements.Add(planElement);
        //        CurrentDayElements.Add(planElement);

        //        //update CurrentDateTime
        //        currentDateTime = planElement.End;

        //        //change previous Location
        //        previousPlanElementLocation.lat = planElement.Lat;
        //        previousPlanElementLocation.lng = planElement.Lng;


        //        //PlanElement with sleeping indicate end of day
        //        if (planElement.ElementType == PlanElementType.Sleeping)
        //        {
        //            CurrentDayElements.Clear();
        //        }
        //    }

            //    return plan;
            //}

        }
}

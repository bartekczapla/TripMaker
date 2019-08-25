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
            var assumptions = new PlanAssumptions(plan.PlanForm);
            var elements = new List<PlanElement>();


            return elements;
        }

















        //public async Task<Plan> GenerateAsync(PlanForm planForm)
        //{
        //    var plan = new Plan(planForm.PlaceName, planForm.Id);

        //    //Destination Info
        //    var destinationInfo = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateBasic(planForm.PlaceId, planForm.Language));

        //    //Accomodation 
        //    Accomodation accomodation;
        //    if(planForm.HasAccomodationBooked && planForm.PlanAccomodation != null)
        //    {
        //        var accomodationInfo = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateBasic(planForm.PlanAccomodation.PlaceId, planForm.Language));
        //        accomodation = new Accomodation(accomodationInfo.Result.geometry.location, accomodationInfo.Result.place_id, accomodationInfo.Result.name, accomodationInfo.Result.formatted_address);
        //        //update planForm.PlanAccomodation
        //        planForm.PlanAccomodation.Lat = accomodation.Location.lat;
        //        planForm.PlanAccomodation.Lng = accomodation.Location.lng;
        //        planForm.PlanAccomodation.FormattedAddress = accomodation.FormattedAddress;
        //        planForm.PlanAccomodation.PlaceName = accomodation.PlaceName;
        //    }
        //    else
        //    {
        //        //if no accomodation, everyday starting point is taken from destination address
        //        accomodation = new Accomodation(destinationInfo.Result.geometry.location , destinationInfo.Result.place_id, destinationInfo.Result.name, destinationInfo.Result.formatted_address);
        //    }


        //    //Time iterator
        //    var currentDateTime = planForm.StartTime.HasValue ? planForm.StartDate.Add(planForm.StartTime.Value) : planForm.StartDate.Add(StartTimeAssumption);
        //    //End time
        //    var endDateTime = planForm.EndTime.HasValue ? planForm.EndDate.Add(planForm.EndTime.Value) : planForm.StartDate.Add(EndTimeAssumption);

        //    //List to hold PlanElements from current day
        //    List<PlanElement> CurrentDayElements = new List<PlanElement>();

        //    //List to hold Plan Element Candidates from api services
        //    List<PlanElementCandidate> PlanElementCandidate = new List<PlanElementCandidate>();
        //    List<PlanElementCandidate> UsedPlanElementCandidate = new List<PlanElementCandidate>();

        //    //Add Sleeping to candidates list
        //    PlanElementCandidate.Add(new PlanElementCandidate(accomodation.PlaceName, accomodation.PlaceId, accomodation.Location, PlanElementType.Sleeping, SleepingDuration));

        //    //starting point from hotel when some error
        //    PlanElementCandidate.Add(new PlanElementCandidate(accomodation.PlaceName, accomodation.PlaceId, accomodation.Location, PlanElementType.Nothing, DoingNothingTime));


        //    //PlanElements iter
        //    int iter = 1;

        //    //StartElement
        //    var startElement = new PlanElement(accomodation.FormattedAddress, accomodation.PlaceId, accomodation.Location.lat, accomodation.Location.lng, iter, currentDateTime, currentDateTime, PlanElementType.Moving, null);
        //    plan.Elements.Add(startElement);

        //    //previous PlanElemnt which hold previous Location for DirectionApi
        //    Location previousPlanElementLocation = Location.Create(startElement.Lat, startElement.Lng);

        //    while (DateTime.Compare(currentDateTime, endDateTime) <= 0)
        //    {
        //        iter += 1;

        //        //declare local variables 
        //        var planElement = new PlanElement(iter, currentDateTime, currentDateTime); 

        //        //decide what to do
        //        var decision = _planElementDecisionMaker.Decide(currentDateTime, CurrentDayElements);

        //        //get candidates
        //        if(!PlanElementCandidate.Any(x=>x.ElementType == decision.ElementType))
        //        {
        //            // var anyChange= await _planElementCandidateFactory.Up(PlanElementCandidate, UsedPlanElementCandidate, decision, planForm, previousPlanElementLocation);
        //            var anyChange = false;
        //            //change decision if no change of list
        //            if (!anyChange)
        //            {
        //                decision.ElementType = PlanElementType.Nothing;
        //            }
        //        }

        //        //Get Plan Element
        //        if (decision.ElementType == PlanElementType.Sleeping)
        //        {
        //            var candidate = PlanElementCandidate.First(x => x.ElementType == decision.ElementType);
        //            planElement.UpdateInformation(candidate.PlaceName, candidate.PlaceId, candidate.Location.lat, candidate.Location.lng, candidate.Duration, candidate.ElementType, candidate.Rating);
        //        }
        //        else if(decision.ElementType == PlanElementType.Eating || decision.ElementType == PlanElementType.Entertainment || decision.ElementType == PlanElementType.Relax || 
        //        decision.ElementType == PlanElementType.Activity || decision.ElementType == PlanElementType.Culture || decision.ElementType == PlanElementType.Sightseeing || 
        //        decision.ElementType == PlanElementType.Partying || decision.ElementType == PlanElementType.Shopping)
        //        {
        //            var candidate=_planElementByUserPreferencesPicker.Pick(PlanElementCandidate, decision.ElementType);
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

        //        if(InterpreteGoogleStatus.IsStatusOk(directionsApiResult.status) && directionsApiResult.routes.Any() && directionsApiResult.routes.FirstOrDefault().legs.Any())
        //        {
        //            var route = directionsApiResult.routes.First().legs.First(); //only 1 leg if no waypoints
        //            var planRoute = new PlanRoute(route.distance.value, route.duration.value);

        //            //update planElement time with time take by route
        //            var routeDuration = TimeSpan.FromSeconds(route.duration.value);
        //            planElement.UpdateDateTimeWithRouteDuration(routeDuration);

        //            //steps of route
        //            foreach(var step in route.steps)
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

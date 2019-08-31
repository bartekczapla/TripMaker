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
        private readonly IGoogleDirectionsApiClient _googleDirectionsApiClient;
        private readonly IGoogleDirectionsInputFactory _googleDirectionsInputFactory;
        private readonly IOptimizePlanElementsOrder _optimizePlanElementsOrder;
        private readonly IPlanElementEatingProvider _planElementEatingProvider;


        public PlanElementsProvider(
            IGoogleDirectionsApiClient googleDirectionsApiClient,
            IGoogleDirectionsInputFactory googleDirectionsInputFactory,
            IOptimizePlanElementsOrder optimizePlanElementsOrder,
            IPlanElementEatingProvider planElementEatingProvider
            )
        {
            _googleDirectionsApiClient = googleDirectionsApiClient;
            _googleDirectionsInputFactory = googleDirectionsInputFactory;
            _optimizePlanElementsOrder = optimizePlanElementsOrder;
            _planElementEatingProvider = planElementEatingProvider;
        }

        public async Task<IList<PlanElement>> GenerateAsync(DecisionArray decisionArray, Plan plan)
        {
            var elements = new List<PlanElement>();

            var optimizedElementsOrder = await _optimizePlanElementsOrder.Optimize(decisionArray, plan, plan.Assumptions.AssumedNumberOfElement); //travel salesman problem optimization

            for (int i = 0; i < optimizedElementsOrder.Count; i++)
            {
                decisionArray.DecisionRows[i].OptimizedPosition = optimizedElementsOrder[i] + 1;
            }

            //Sort by optimized position
            decisionArray.DecisionRows = decisionArray.DecisionRows.OrderBy(x => x.OptimizedPosition).ToList();

            var iterParams = new PlanElementIteratorParams(plan.StartLocation, plan.PlanForm.StartDateTime, plan.Assumptions);

            while (DateTime.Compare(iterParams.CurrentDateTime, plan.PlanForm.EndDateTime) <= 0)
            {
                PlanElement planElement = null;
                //EATING
                if (iterParams.IsTimeForMeal())
                {
                    var elementEndTime = iterParams.CreateEndDateTime(plan.Assumptions.EatingDuration);
                    var candidate = await _planElementEatingProvider.GenerateAsync(decisionArray, plan,iterParams.WhichMeal,iterParams);
                    iterParams.CheckNextMeal();
                    planElement = new PlanElement(candidate.PlaceName, candidate.PlaceId, candidate.FormattedAddress, iterParams.CurrentDateTime, elementEndTime, candidate.Location.lat, candidate.Location.lng, iterParams.OrderNo, candidate.Rating, candidate.Price, candidate.Popularity, PlanElementType.Eating);
                }
                //SLEEPING
                else if (iterParams.IsTimeForSleep())
                {
                    iterParams.IsSleep = true;
                    var elementEndTime = iterParams.CreateEndDateTime(plan.Assumptions.SleepDuration);
                    if (plan.PlanForm.HasAccomodationBooked)
                    {
                        planElement = new PlanElement(plan.PlanAccomodation.PlaceName, plan.PlanAccomodation.PlaceId, plan.PlanAccomodation.FormattedAddress, iterParams.CurrentDateTime, elementEndTime, plan.PlanAccomodation.Lat, plan.PlanAccomodation.Lng, iterParams.OrderNo, plan.PlanAccomodation.Rating, null, null, PlanElementType.Sleeping);
                    }
                    else
                    {
                        planElement = new PlanElement(plan.PlanForm.PlaceName, plan.PlanForm.PlaceId, String.Empty, iterParams.CurrentDateTime, elementEndTime, plan.Latitude, plan.Longitude, iterParams.OrderNo, plan.Rating, null, null, PlanElementType.Sleeping);
                    }
                }
                //OTHER PLAN ELEMENTS
                else
                {
                    var foundRow = false;
                    var elementEndTime = iterParams.CreateEndDateTime(plan.Assumptions.PlanElementDuration);
                    while (!foundRow)
                    {
                        if (iterParams.LeftRows.Any(x => x.Candidate.IsOpen(iterParams.CurrentDateTime))) //first check lefted row which was temporary closed
                        {
                            var leftedRow = iterParams.LeftRows.First(x => x.Candidate.IsOpen(iterParams.CurrentDateTime));
                            planElement = PlanElement.Create(decisionArray.DecisionRows[iterParams.CurrentDecisionRowIndex], iterParams.OrderNo, iterParams.CurrentDateTime, elementEndTime);
                            foundRow = true;
                        }
                        else if (decisionArray.DecisionRows[iterParams.CurrentDecisionRowIndex].Candidate.IsOpen(iterParams.CurrentDateTime)) //decision row is open
                        {

                            planElement = PlanElement.Create(decisionArray.DecisionRows[iterParams.CurrentDecisionRowIndex], iterParams.OrderNo, iterParams.CurrentDateTime, elementEndTime);
                            foundRow = true;
                            iterParams.CurrentDecisionRowIndex += 1;
                        }
                        else //decision row is closed
                        {
                            iterParams.LeftRows.Add(decisionArray.DecisionRows[iterParams.CurrentDecisionRowIndex]);
                            iterParams.CurrentDecisionRowIndex += 1;
                        }
                    }
                }

                if (planElement == null)
                    continue;


                //DIRECTIONS
                var directionsApiInput = _googleDirectionsInputFactory.Create(iterParams.CurrentLocation, iterParams.NextLocation, iterParams.travelMode, iterParams.CurrentDateTime);
                var directionsApiResult = await _googleDirectionsApiClient.GetAsync(directionsApiInput);
                if (directionsApiResult.IsOk)
                {
                    var route = directionsApiResult.routes.First().legs.First(); //only 1 leg if no waypoints
                    var planRoute = new PlanRoute(route.distance.value, route.duration.value, iterParams.travelMode);

                    foreach (var step in route.steps) //steps of route
                    {
                        planRoute.Steps.Add(new PlanRouteStep(step.distance.value, step.duration.value,
                                    step.start_location.lat, step.start_location.lng,
                                  step.end_location.lat, step.end_location.lng,
                                  InterpreteEnums.InterpreteTravelMode(step.travel_mode),
                                  step.html_instructions, step.maneuver));
                    }

                    //update plan element times
                    planElement.UpdateDateTimeWithRouteDuration(planRoute.TimeDuration);
                    planElement.EndingRoute = planRoute;

                }

                elements.Add(planElement); //add to plan list
                iterParams.SetCurrentLocation(planElement.Lat, planElement.Lng); // update currentLocation in iterParams
                iterParams.CurrentDateTime = planElement.End; //update current time in iterParams
                ++iterParams.OrderNo; //increase iter)
                iterParams.ClearIfEndOfCurrentDay();
            }

            return elements;
        }
    }
}
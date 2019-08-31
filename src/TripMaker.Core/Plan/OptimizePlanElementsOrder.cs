using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.Enums;
using TripMaker.ExternalServices.Helpers;
using Abp.UI;

namespace TripMaker.Plan
{
    public class OptimizePlanElementsOrder : IOptimizePlanElementsOrder
    {
        private readonly IGoogleDirectionsApiClient _googleDirectionsApiClient;
        private readonly IGoogleDirectionsInputFactory _googleDirectionsInputFactory;

        public OptimizePlanElementsOrder(IGoogleDirectionsApiClient googleDirectionsApiClient, IGoogleDirectionsInputFactory googleDirectionsInputFactory)
        {
            _googleDirectionsApiClient = googleDirectionsApiClient;
            _googleDirectionsInputFactory = googleDirectionsInputFactory;
        }

        public async Task<IList<int>> Optimize(DecisionArray decisionArray, Plan plan, int? elementsCount=null)
        {
            if (!elementsCount.HasValue)
                elementsCount = decisionArray.DecisionRows.Count;

            var waypoints = decisionArray.DecisionRows.Take(elementsCount.Value)
                                       .Select(x => x.Candidate.Location).ToList();

            var startSeconds = GooglePlaceCalculator.ConvertToUnixTimestamp(plan.PlanForm.StartDateTime);

            GoogleTravelMode mode;
            if (plan.PlanForm.PreferedTravelModes.Contains(GoogleTravelMode.Driving))
                mode = GoogleTravelMode.Driving;
            else if (plan.PlanForm.PreferedTravelModes.Contains(GoogleTravelMode.Walking))
                mode = GoogleTravelMode.Walking;
            else if (plan.PlanForm.PreferedTravelModes.Contains(GoogleTravelMode.Bicycling))
                mode = GoogleTravelMode.Bicycling;
            else
                mode = GoogleTravelMode.Transit;


            var optimizeApiInput = _googleDirectionsInputFactory.CreateOptimizedWaypoints(plan.StartLocation, plan.StartLocation, mode, waypoints, startSeconds);

            var result = await _googleDirectionsApiClient.GetAsync(optimizeApiInput);

            if(result.IsOk)
            {
                var optimizedOrder = result.routes.First();
                return optimizedOrder.waypoint_order;
            } else
            {
                throw new UserFriendlyException($"Nie udało się zoptymalizować kolejności elementów planu (Problem komiwojażera)!");
            }

        }


    }
}

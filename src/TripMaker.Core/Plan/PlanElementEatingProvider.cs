using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.Enums.PlanFormEnums;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanElementEatingProvider : IPlanElementEatingProvider
    {
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceNearbySearchApiClient _googlePlaceNearbySearchApiClient;
        private readonly IGooglePlaceDetailsInputFactory _googlePlaceDetailsInputFactory;
        private readonly IGooglePlaceNearbySearchInputFactory _googlePlaceNearbySearchInputFactory;
        private readonly IDecisionRowFactory _decisionRowFactory;
        private readonly ISawMethod _sawMethod;

        public PlanElementEatingProvider(
            IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, 
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory,
            IGooglePlaceNearbySearchInputFactory googlePlaceNearbySearchInputFactory,
            IDecisionRowFactory decisionRowFactory,
            ISawMethod sawMethod)
        {
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlaceDetailsInputFactory = googlePlaceDetailsInputFactory;
            _googlePlaceNearbySearchInputFactory = googlePlaceNearbySearchInputFactory;
            _decisionRowFactory = decisionRowFactory;
            _sawMethod = sawMethod;
        }

        public async Task<PlanElementCandidate> GenerateAsync(DecisionArray decisionArray, Plan plan, int whichMeal, PlanElementIteratorParams iterParams)
        {
            var test = true;
            //choose type based on preferences
            var type = (plan.PlanForm.FoodPreference == FoodPreference.OnlyRestaurant || (plan.PlanForm.FoodPreference == FoodPreference.Mixed && whichMeal == 2)) ? GooglePlaceTypeCategory.Restaurant : GooglePlaceTypeCategory.Food;
            var candidates = new List<PlanElementCandidate>();
            var decisionRows = new List<DecisionRow>();
            var googleNearbyFoodInput = _googlePlaceNearbySearchInputFactory.Create(iterParams.CurrentLocation, type);
            var nearbyFoodResults = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyFoodInput);
            int counter = 1;
            foreach (var nr in nearbyFoodResults.results)
            {

                var details = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAllUseful(nr.place_id));
                if (details.IsOk)
                {
                    var candidate = new PlanElementCandidate(details.Result.name, details.Result.place_id, details.Result.formatted_address, details.Result.geometry.location, details.Result.opening_hours, details.Result.types, details.Result.rating, details.Result.price_level, details.Result.user_ratings_total);
                    if (test)
                        return candidate;

                    candidates.Add(candidate);
                }
                ++counter;
                if (counter > 10 && candidates.Count > 5) break;
            }



            var iter = 1;
            foreach (var candidate in candidates)
            {
                decisionRows.Add(_decisionRowFactory.Create(candidate, iter, iterParams.CurrentLocation));
                ++iter;
            }

            var minVector = DecisionArray.GetMinVector(decisionRows);
            var maxVector = DecisionArray.GetMaxVector(decisionRows);
            foreach (var decisionRow in decisionRows)
            {
                decisionRow.NormalizedScore = _sawMethod.CalculateNormalizedScore(SawNormalizationMethod.LinearFirstType, decisionArray.WeightVector, decisionRow.DecisionValues, minVector, maxVector);
            }

            var result = decisionRows.OrderByDescending(x => x.NormalizedScore).FirstOrDefault(x => x.Candidate.IsOpen(iterParams.CurrentDateTime));

            if (result == null)
                throw new UserFriendlyException($"Nie udało się znaleźć żadnego miejsca, gdzie można zjeść w pobliżu o godz: {iterParams.CurrentDateTime}");

            return result.Candidate;

        }
    }
}

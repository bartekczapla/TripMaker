using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;
using static TripMaker.Plan.PlanHelpers;

namespace TripMaker.Plan
{
    public class PlanProvider : PlanConsts, IPlanProvider
    {
        private readonly IWeightVectorProvider _weightVectorProvider;
        private readonly IPlanElementCandidateFactory _planElementCandidateFactory;
        private readonly ISawMethod _sawMethod;
        private readonly IDecisionRowFactory _decisionRowFactory;
        private readonly IPlanElementsProvider _planElementsProvider;

        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceDetailsInputFactory _googlePlaceDetailsInputFactory;

        public PlanProvider(IWeightVectorProvider weightVectorProvider, IPlanElementCandidateFactory planElementCandidateFactory,
            IDecisionRowFactory decisionRowFactory, ISawMethod sawMethod, IPlanElementsProvider planElementsProvider,
            IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient, IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory)
        {
            _weightVectorProvider = weightVectorProvider;
            _planElementCandidateFactory = planElementCandidateFactory;
            _decisionRowFactory = decisionRowFactory;
            _sawMethod = sawMethod;
            _planElementsProvider = planElementsProvider;
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceDetailsInputFactory = googlePlaceDetailsInputFactory;
        }

        public async Task<Plan> GenerateAsync(PlanForm planForm)
        {
            // 1. Create decision array
            var DecisionArray = new DecisionArray();

            // 2. Create plan object. Validate desitnation and accomodation.
            var destinationInfo = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAllUseful(planForm.PlaceId));
            var plan = new Plan(destinationInfo.Result.name, destinationInfo.Result.geometry.location.lat, destinationInfo.Result.geometry.location.lng,
                              (decimal?)destinationInfo.Result.rating, (decimal?)destinationInfo.Result.user_ratings_total, destinationInfo.Result.formatted_address);

            if (planForm.HasAccomodationBooked)
            {
                var accomodationInfo= await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAllUseful(planForm.AccomodationId));
                plan.PlanAccomodation = new PlanAccomodation(accomodationInfo.Result.geometry.location.lat, accomodationInfo.Result.geometry.location.lng, planForm.AccomodationId,
                                                           accomodationInfo.Result.name, accomodationInfo.Result.formatted_address, (decimal?)accomodationInfo.Result.rating, (decimal?)accomodationInfo.Result.user_ratings_total);

                var distance = CalculateDistance(plan.Lat, plan.Lng, plan.PlanAccomodation.Lat, plan.PlanAccomodation.Lng);

                if(distance > MaximumDistanceToAccomodation) //more than 15km
                    throw new UserFriendlyException($"Odległość między celem podróży a miejscem zakwaterowania nie może być większa nić {(int)(MaximumDistanceToAccomodation/1000)} km");
            }

            plan.PlanForm = planForm;

            // 3. Generate weight vector based on user preferences
            DecisionArray.WeightVector = _weightVectorProvider.Generate(planForm);
            plan.PlanFormWeightVector = PlanFormWeightVector.Create(DecisionArray.WeightVector);

            // 4. Get plan candidates 
            var candidates = await _planElementCandidateFactory.GetCandidates(plan, DecisionArray.WeightVector);

            //5. Create decision row with values based on candidates
            int init = 1;
            foreach (var candidate in candidates)
            {
                DecisionArray.DecisionRows.Add(_decisionRowFactory.Create(candidate, init, plan.StartLocation));
                ++init;
            }

            // 6. SCORE FUNCTION -> SAW Normalization (3 types - chosen first) and then calculate Score
            var minVector = DecisionArray.GetMinVector();
            var maxVector = DecisionArray.GetMaxVector();
            foreach(var decisionRow in DecisionArray.DecisionRows)
            {
                decisionRow.NormalizedScore = _sawMethod.CalculateNormalizedScore(SawNormalizationMethod.LinearFirstType, DecisionArray.WeightVector, decisionRow.DecisionValues, minVector, maxVector);
            }

            // 7. Clasification
            DecisionArray.DecisionRows = DecisionArray.DecisionRows.OrderByDescending(x => x.NormalizedScore).ToList();
            int newPos = 1;
            foreach(var row in DecisionArray.DecisionRows)
            {
                row.ScorePosition = newPos;
                ++newPos;
            }

            // 8. Create Plan based on decision array and optimize it


            plan.Elements = await _planElementsProvider.GenerateAsync(DecisionArray, plan);

            return plan;
        }
    }
}


using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Helpers;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanElementCandidateFactory : PlanConsts, IPlanElementCandidateFactory
    {
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceNearbySearchApiClient _googlePlaceNearbySearchApiClient;
        private readonly IGooglePlaceDetailsInputFactory _googlePlaceDetailsInputFactory;
        private readonly IGooglePlaceNearbySearchInputFactory _googlePlaceNearbySearchInputFactory;

        public PlanElementCandidateFactory(
            IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient, 
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, 
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory,
            IGooglePlaceNearbySearchInputFactory googlePlaceNearbySearchInputFactory
            )
        {
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlaceDetailsInputFactory = googlePlaceDetailsInputFactory;
            _googlePlaceNearbySearchInputFactory = googlePlaceNearbySearchInputFactory;
        }


        public async Task<IList<PlanElementCandidate>> GetCandidates(Plan plan, WeightVector weightVector)
        {
            var candidates = new List<PlanElementCandidate>();

            PlanElementType[] planElementTypes = new PlanElementType[]
            {
                PlanElementType.Entertainment,
                PlanElementType.Relax,
                PlanElementType.Activity,
                PlanElementType.Culture,
                PlanElementType.Sightseeing,
                PlanElementType.Partying,
                PlanElementType.Shopping,
            };


            foreach(var planElementType in planElementTypes)
            {
                var googlePlaceTypes = GooglePlaceTypes.Table.Where(x => x.PlanElementType == planElementType).ToList();

                foreach (var type in googlePlaceTypes)
                {
                    var nearbySearchInput = _googlePlaceNearbySearchInputFactory.Create(plan.StartLocation, (int)MaximumDistanceToAccomodation, type);
                    var nearbyResults = await _googlePlaceNearbySearchApiClient.GetAsync(nearbySearchInput);
                    int counter = 1;
                    foreach (var nr in nearbyResults.results)
                    {

                        var details = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAllUseful(nr.place_id));
                        if (details.IsOk)
                        {
                            var candidate = new PlanElementCandidate(details.Result.name, details.Result.place_id, details.Result.formatted_address, details.Result.geometry.location, details.Result.opening_hours, details.Result.types, details.Result.rating, details.Result.price_level, details.Result.user_ratings_total);
                            if (!candidates.Any(x => x.PlaceId == candidate.PlaceId)) candidates.Add(candidate);
                        }
                        ++counter;
                    }

                    WeightVectorLabel weightVectorLabel = WeightVector.TranslateLabel(planElementType);

                    if ((plan.PlanForm.IsOverOneWeek || weightVector.GetLabelValue(weightVectorLabel) >= 0.1m) && nearbyResults.IsMoreResults)
                    {
                        var nearbyResults2 = await _googlePlaceNearbySearchApiClient.GetNextPageTokenAsync(nearbyResults.next_page_token);
                        foreach (var nr in nearbyResults2.results)
                        {

                            var details = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreateAllUseful(nr.place_id));
                            if (details.IsOk)
                            {
                                var candidate = new PlanElementCandidate(details.Result.name, details.Result.place_id, details.Result.formatted_address, details.Result.geometry.location, details.Result.opening_hours, details.Result.types, details.Result.rating, details.Result.price_level, details.Result.user_ratings_total);

                                if (!candidates.Any(x=>x.PlaceId == candidate.PlaceId))candidates.Add(candidate);
                            }
                            ++counter;
                        }
                    }

                }

                if (candidates.Count > 35)
                    break;

            }

            if (candidates.Count == 0)
                throw new UserFriendlyException($"Nie znaleziono żadnych potencjalnych kandydatów na elementy planu");

            return candidates;
        }

    }
}

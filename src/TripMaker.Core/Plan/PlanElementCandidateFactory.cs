using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Helpers;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanElementCandidateFactory : PlanElementsAssumptions, IPlanElementCandidateFactory
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

        public PlanElementCandidateFactory(IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient, IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller,
            IGoogleDirectionsApiClient googleDirectionsApiClient,
            IGoogleDirectionsInputFactory googleDirectionsInputFactory, IGoogleDistanceMatrixInputFactory googleDistanceMatrixInputFactory,
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory, IGooglePlaceNearbySearchInputFactory googlePlaceNearbySearchInputFactory,
            IGooglePlaceSearchInputFactory googlePlaceSearchInputFactory,
            IPlanElementDecisionMaker planElementDecisionMaker)
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
        }


        public async Task<IList<PlanElementCandidate>> GetCandidates(Plan plan, WeightVector weightVector)
        {
            var candidates = new List<PlanElementCandidate>();





            return candidates;
        }






        //public async Task<bool> UpdateListAsync(IList<PlanElementCandidate> candidates, IList<PlanElementCandidate> usedCandidates, PlanElementDecision decision, PlanForm planForm, Location previousLocation)
        //{
        //    if (decision.ElementType == PlanElementType.Eating)
        //    {
        //        var googleNearbyRestaurantInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Restaurant);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyRestaurantInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach(var item in nearbyResult.results)
        //        {
        //            if(!usedCandidates.Any(x=>x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Eating, EatingDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Entertainment)
        //    {
        //        var googleNearbyEntertainmentInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Entertainment);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyEntertainmentInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Entertainment, EntertainmentDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Relax)
        //    {
        //        var googleNearbyInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Relax);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Relax, RelaxDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Activity)
        //    {
        //        var googleNearbyInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Activity);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Activity, ActivityDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Culture)
        //    {
        //        var googleNearbyInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Culture);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Culture, CultureDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Sightseeing)
        //    {
        //        var googleNearbyInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Sightseeing);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Sightseeing, SightseeingDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Partying)
        //    {
        //        var googleNearbyInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Partying);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Partying, PartyingDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else if (decision.ElementType == PlanElementType.Shopping)
        //    {
        //        var googleNearbyInput = _googlePlaceNearbySearchInputFactory.Create(previousLocation, planForm.Language, GooglePlaceTypeCategory.Shopping);
        //        var nearbyResult = await _googlePlaceNearbySearchApiClient.GetAsync(googleNearbyInput);
        //        if (!InterpreteGoogleStatus.IsStatusOk(nearbyResult.status)) //if request error, add already usedCandidates
        //        {
        //            return false;
        //        }

        //        var anyChange = false;
        //        foreach (var item in nearbyResult.results)
        //        {
        //            if (!usedCandidates.Any(x => x.PlaceId == item.place_id)) //place hasnot been used
        //            {
        //                anyChange = true;
        //                candidates.Add(new PlanElementCandidate(item.name, item.place_id, Location.Create(item.geometry.location.lat, item.geometry.location.lng), PlanElementType.Shopping, ShoppingDuration));
        //            }
        //        }
        //        return anyChange;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}

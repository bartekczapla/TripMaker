using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.Plan
{
    public class PlanManager : IPlanManager
    {

        private readonly IRepository<Plan> _planRepository;
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceSearchApiClient _googlePlaceSearchApiClient;
        private readonly IGooglePlaceNearbySearchApiClient _googlePlaceNearbySearchApiClient;
        private readonly IGooglePlacePhotosApiCaller _googlePlacePhotosApiCaller;

        public PlanManager(IRepository<Plan> planRepository, IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller)
        {
            _planRepository=planRepository;
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceSearchApiClient = googlePlaceSearchApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;

        }

        public async Task CreateAsync(Plan plan)
        {
            var test =await _googlePlaceDetailsApiClient.GetAllAsync(plan.PlaceId);
            var test2 = await _googlePlaceNearbySearchApiClient.GetAllAsync(new Location { lat = test.Result.geometry.location.lat,
                                                                                            lng = test.Result.geometry.location.lng,}, 10000);
            var test3 = await _googlePlaceSearchApiClient.GetAllAsync("Skomielna Biała");
            Console.WriteLine("stop");
           // await _planRepository.InsertAsync(plan);
        }
    }
}

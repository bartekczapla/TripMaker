using Abp.Domain.Repositories;
using Abp.Events.Bus;
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
        private readonly IRepository<PlanForm> _planFormRepository;
        private readonly IRepository<PlanElement> _planElementRepository;

        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;
        private readonly IGooglePlaceSearchApiClient _googlePlaceSearchApiClient;
        private readonly IGooglePlaceNearbySearchApiClient _googlePlaceNearbySearchApiClient;
        private readonly IGooglePlacePhotosApiCaller _googlePlacePhotosApiCaller;
        public IEventBus EventBus { get; set; }


        public PlanManager(
            IRepository<Plan> planRepository,
            IRepository<PlanForm> planFormRepository,
            IRepository<PlanElement> planElementRepository,
            IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceSearchApiClient googlePlaceSearchApiClient,
            IGooglePlaceNearbySearchApiClient googlePlaceNearbySearchApiClient, 
            IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller
            )
        {
            _planRepository=planRepository;
            _planFormRepository = planFormRepository;
            _planElementRepository = planElementRepository;
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceSearchApiClient = googlePlaceSearchApiClient;
            _googlePlaceNearbySearchApiClient = googlePlaceNearbySearchApiClient;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Plan> CreateAsync(PlanForm planForm)
        {
           // await EventBus.TriggerAsync(new EventSearchPlace(plan));

            Console.WriteLine("stop");

            return new Plan(planForm.PlaceName);
        }
    }
}

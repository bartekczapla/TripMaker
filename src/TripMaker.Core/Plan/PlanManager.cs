using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanManager : IPlanManager
    {
        private readonly IRepository<Plan> _planRepository;
        private readonly IRepository<PlanForm> _planFormRepository;
        private readonly IRepository<PlanElement> _planElementRepository;
        private readonly IRepository<PlanRoute> _planRouteRepository;
        private readonly IRepository<PlanRouteStep> _planRouteStepRepository;
        private readonly IPlanFormPolicy _planFormPolicy;
        private readonly IPlanElementsProvider _planElementsProvider;
        public IEventBus EventBus { get; set; }


        public PlanManager
            (
            IRepository<Plan> planRepository,
            IRepository<PlanForm> planFormRepository,
            IRepository<PlanElement> planElementRepository,
            IRepository<PlanRoute> planRouteRepository,
            IRepository<PlanRouteStep> planRouteStepRepository,

            IPlanElementsProvider planElementsProvider,
            IPlanFormPolicy planFormPolicy
            )
        {
            _planRepository=planRepository;
            _planFormRepository = planFormRepository;
            _planElementRepository = planElementRepository;
            _planElementsProvider = planElementsProvider;
            _planRouteRepository = planRouteRepository;
            _planRouteStepRepository = planRouteStepRepository;
            _planFormPolicy = planFormPolicy;
            EventBus = NullEventBus.Instance;
        }

        public async Task<Plan> CreateAsync(PlanForm planForm)
        {
            await _planFormPolicy.CheckFormValidAsync(planForm); //check if planForm object has valid data

            await EventBus.TriggerAsync(new EventSearchPlace(planForm)); //update SearchedPlaces DB

            await _planFormRepository.InsertAsync(planForm);
   

            var plan = await _planElementsProvider.GenerateAsync(planForm);


            //insert plan to DB
            await _planRepository.InsertAsync(plan);

            foreach(var element in plan.Elements)
            {
                await _planElementRepository.InsertAsync(element);

                if(element.EndingRoute != null)
                {
                    await _planRouteRepository.InsertAsync(element.EndingRoute);

                    foreach(var step in element.EndingRoute.Steps)
                    {
                        await _planRouteStepRepository.InsertAsync(step);
                    }
                }
            }

            return plan;
        }

        public async Task<Plan> GetAsync(int planId)
        {
            var plan = await _planRepository
                .GetAll()
                .Include(e => e.Elements)
                .ThenInclude(r=>r.EndingRoute)
                .Where(e => e.Id == planId)
                .FirstOrDefaultAsync();

            if (plan == null)
            {
                throw new UserFriendlyException($"Could not found the plan with id: {planId}");
            }

            return plan;
        }
    }
}

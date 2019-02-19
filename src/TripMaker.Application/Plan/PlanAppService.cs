using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using TripMaker.Configuration;
using TripMaker.ExternalServices;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.GooglePlace;

namespace TripMaker.Plan
{
    public class PlanAppService : IPlanAppService
    {
        private readonly IPlanManager _planManager;

        public PlanAppService(IPlanManager planManager)
        {
            _planManager = planManager;

    }

        public async Task<ListResultDto<PlanListDto>> GetPlanAsync(GetPlanInput input)
        {
            var plan = new Plan(input.PlaceInfo.Locality, input.PlaceInfo.PlaceId, input.StartDate, input.EndDate);

            await _planManager.CreateAsync(plan);

            var temp = new PlanListDto() { Title = "test", Date = new DateTime() };
            var list = new List<PlanListDto>();
            list.Add(temp);

            return new ListResultDto<PlanListDto>(list);

            
        }
    }
}

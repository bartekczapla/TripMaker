using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Tutorial.Dto;
using TripMaker.Plan.Models;
using Abp.AutoMapper;

namespace TripMaker.Plan
{
    public class PlanAppService : TripMakerAppServiceBase, IPlanAppService
    {
        private readonly IPlanManager _planManager;

        public PlanAppService(IPlanManager planManager)
        {
            _planManager = planManager;

        }

        public async Task<ListResultDto<PlanListDto>> GetPlanAsync(GetPlanInput input)
        {
            var plan = new Plan(input.PlaceName, input.PlaceId, input.StartDate, input.EndDate);

            await _planManager.CreateAsync(plan);

            var temp = new PlanListDto() { Title = "test", Date = new DateTime() };
            var list = new List<PlanListDto>();
            list.Add(temp);

            return new ListResultDto<PlanListDto>(list);            
        }

        public async Task<ListResultDto<PlanListDto>> GetTestPlanAsync()
        {         
            var input =  PlanCommon.CreateTestInput().MapTo<PlanForm>(); 
           // await _planManager.CreateAsync(plan);

            return new ListResultDto<PlanListDto>(new List<PlanListDto>());
        }
    }
}

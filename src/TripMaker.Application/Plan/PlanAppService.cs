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
using Abp.AutoMapper;

namespace TripMaker.Plan
{
    public class PlanAppService : IPlanAppService
    {
        private readonly IPlanManager _planManager;

        public PlanAppService(IPlanManager planManager)
        {
            _planManager = planManager;

        }

        public async Task<ListResultDto<PlanDto>> GetPlanAsync(GetPlanInput input)
        {

            return new ListResultDto<PlanDto>();            
        }

        public async Task<PlanDto> GetTestPlanAsync()
        {         
            var input =  PlanCommon.CreateTestInput().MapTo<PlanForm>(); 
            var result= await _planManager.CreateAsync(input);

            return result.MapTo<PlanDto>();
        }
    }
}

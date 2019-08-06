using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using TripMaker.Authorization;
using TripMaker.Authorization.Roles;
using TripMaker.Authorization.Users;
using TripMaker.Roles.Dto;
using TripMaker.Users.Dto;
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

        public async Task<ListResultDto<PlanDto>> GetPlanAsync(GetPlanInput input)
        {

            return new ListResultDto<PlanDto>();            
        }

        public async Task<PlanDto> GetTestPlanAsync()
        {
            var input =  PlanCommon.CreateTestInput().MapTo<PlanForm>(); 
            var result= await _planManager.CreateAsync(input);

            await CurrentUnitOfWork.SaveChangesAsync();

            var dto = result.MapTo<PlanDto>();

            return dto;
        }



        public async Task<PlanDto> GetTestPlanByIdAsync(int planId)
        {
            planId = 5;
            var result = await _planManager.GetAsync(planId);

            var dto= result.MapTo<PlanDto>();

            return dto;
        }
    }
}

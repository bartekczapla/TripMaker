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
using static TripMaker.Plan.PlanCommon;

namespace TripMaker.Plan
{
    public class PlanAppService : TripMakerAppServiceBase, IPlanAppService
    {
        private readonly IPlanManager _planManager;

        public PlanAppService(IPlanManager planManager)
        {
            _planManager = planManager;

        }

        public async Task<PlanDto> CreateAsync(CreatePlanInput input)
        {
            var planForm = input.CreatePlanForm();
            var result = await _planManager.CreateAsync(planForm);
            await CurrentUnitOfWork.SaveChangesAsync();
            var dto = result.MapTo<PlanDto>();
            return dto;            
            
        }

        public async Task<PlanDto> GetTestPlanAsync()
        {
            var inputDto = PlanCommon.CreateTestInput();
            var planForm = inputDto.CreatePlanForm();
            var result = await _planManager.CreateAsync(planForm);
            await CurrentUnitOfWork.SaveChangesAsync();
            var dto = result.MapTo<PlanDto>();
            return dto;
        }

    }
}

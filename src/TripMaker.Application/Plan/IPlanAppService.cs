using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace TripMaker.Plan
{
    public interface IPlanAppService : IApplicationService
    {
        Task<ListResultDto<PlanListDto>> GetPlanAsync(GetPlanInput input);

    }
}

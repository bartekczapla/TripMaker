using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Plan;
using TripMaker.UserPlans.Dto;

namespace TripMaker.UserPlans
{
    public interface IUserPlansAppService : IApplicationService
    {
        Task<ListResultDto<UserPlansListDto>> GetAllUserPlansAsync();

        Task<PlanDto> GetDetailAsync(EntityDto<int> input);

        Task<bool> DeleteAsync(EntityDto<int> input);
    }
}

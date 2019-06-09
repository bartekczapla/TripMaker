using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.UserPlans.Dto;

namespace TripMaker.UserPlans
{
    public interface IUserPlansAppService : IApplicationService
    {
        Task<ListResultDto<UserPlansListDto>> GetAllUserPlansAsync(GetAllUserPlansInput input);
    }
}

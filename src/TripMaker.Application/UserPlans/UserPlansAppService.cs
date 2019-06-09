using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using TripMaker.UserPlans.Dto;
using TripMaker.UserPlans.Interfaces;

namespace TripMaker.UserPlans
{
    public class UserPlansAppService : TripMakerAppServiceBase, IUserPlansAppService
    {
        private readonly IUserPlansManager _userPlansManager;

        public UserPlansAppService(IUserPlansManager userPlansManager)
        {
            _userPlansManager = userPlansManager;
        }

        public async Task<ListResultDto<UserPlansListDto>> GetAllUserPlansAsync(GetAllUserPlansInput input)
        {
            var user = new Authorization.Users.User();
            user.Id = 3;
            var plans = await _userPlansManager.GetAllUserPlansAsync(user);

            return new ListResultDto<UserPlansListDto>(UserPlansCommon.MapResult(plans));
        }
    }
}

using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TripMaker.Controllers
{
    public abstract class TripMakerControllerBase: AbpController
    {
        protected TripMakerControllerBase()
        {
            LocalizationSourceName = TripMakerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

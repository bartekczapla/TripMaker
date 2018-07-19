using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TripMaker.Configuration.Dto;

namespace TripMaker.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TripMakerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

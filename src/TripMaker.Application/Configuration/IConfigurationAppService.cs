using System.Threading.Tasks;
using TripMaker.Configuration.Dto;

namespace TripMaker.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

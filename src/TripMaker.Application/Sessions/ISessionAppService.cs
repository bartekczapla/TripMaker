using System.Threading.Tasks;
using Abp.Application.Services;
using TripMaker.Sessions.Dto;

namespace TripMaker.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

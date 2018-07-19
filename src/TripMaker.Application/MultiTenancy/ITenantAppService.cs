using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TripMaker.MultiTenancy.Dto;

namespace TripMaker.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

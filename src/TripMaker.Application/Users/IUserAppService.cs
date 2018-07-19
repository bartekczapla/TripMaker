using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TripMaker.Roles.Dto;
using TripMaker.Users.Dto;

namespace TripMaker.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}

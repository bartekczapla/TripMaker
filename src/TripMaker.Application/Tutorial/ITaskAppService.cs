
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TripMaker.Tutorial.Dto;

namespace TripMaker.Tutorial
{
    public interface ITaskAppService :IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
        Task Create(CreateTaskInput input);
    }
}

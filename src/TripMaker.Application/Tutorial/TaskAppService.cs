using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Tutorial.Dto;

namespace TripMaker.Tutorial
{
    public class TaskAppService : TripMakerAppServiceBase, ITaskAppService
    {
        private readonly IRepository<SimpleTask> _taskRepository;

        public TaskAppService(IRepository<SimpleTask> taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .Include(t => t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(ObjectMapper.Map<List<TaskListDto>>(tasks));


        }

        public async Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<SimpleTask>(input);
            await _taskRepository.InsertAsync(task);
        }
    }
}

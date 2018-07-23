using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using TripMaker.Tutorial;
using TripMaker.Tutorial.Dto;
using System.Linq;
using Abp.Runtime.Validation;

namespace TripMaker.Tests.Tutorial
{
    public class TaskAppService_Tests : TripMakerTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            _taskAppService = Resolve<ITaskAppService>();
        }

        [Fact]
        public async Task Should_Create_New_Task_With_Title()
        {

            await _taskAppService.Create(new CreateTaskInput { Title = "Nowy", Description = "Opis", AssignedPersonId = 1 });

            UsingDbContext(context =>
            {
                var task1 = context.Tasks.FirstOrDefault(t => t.Title == "Nowy");
                task1.ShouldNotBeNull();
            });
        }


        [Fact]
        public async Task Should_Not_Create_New_Task_Without_Title()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _taskAppService.Create(new CreateTaskInput
                {
                    Title = null
                });
            });
        }



        [Fact]
        public async Task Should_Get_All_Tasks()
        {
            // Act
            var output = await _taskAppService.GetAll(new GetAllTasksInput());

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
            output.Items.Count(t => t.AssignedPersonName != null).ShouldBeGreaterThan(0);
           // output.Items.Count.Equals(1);
        }
    
    }
}

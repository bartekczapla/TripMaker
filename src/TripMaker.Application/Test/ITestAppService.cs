using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripMaker.Test
{
    public interface ITestAppService : IApplicationService
    {
        Task GetTestAsync();

    }
}

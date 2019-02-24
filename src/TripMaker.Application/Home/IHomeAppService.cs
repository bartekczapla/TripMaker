using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Home.Dto;

namespace TripMaker.Home
{
    public interface IHomeAppService : IApplicationService
    {
        Task<ListResultDto<SearchedPlaceDto>> GetMostSearchedPlacesAsync();

    }
}

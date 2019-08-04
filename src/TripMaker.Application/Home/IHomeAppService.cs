using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Home.Dto;
using TripMaker.Home.Models;

namespace TripMaker.Home
{
    public interface IHomeAppService : IApplicationService
    {
        Task<ListResultDto<SearchedPlaceAndPhoto>> GetMostSearchedPlacesAsync();

        Task<bool> CreateContactUsAsync(ContactUsDto input);

    }
}

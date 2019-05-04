using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripMaker.Home.Dto;
using TripMaker.Home.Models;

namespace TripMaker.Home
{
    public class HomeAppService : TripMakerAppServiceBase, IHomeAppService
    {
        private readonly IRepository<SearchedPlace> _searchedPlaceRepository;
        private readonly IRepository<ContactUs> _contactUsRepository;

        public HomeAppService(IRepository<SearchedPlace> searchedPlaceRepository, IRepository<ContactUs> contactUsRepository)
        {
            _searchedPlaceRepository = searchedPlaceRepository;
            _contactUsRepository = contactUsRepository;

        }

        public async Task<bool> CreateContactUsAsync(ContactUsDto input)
        {
            var contact = new ContactUs(input.Name, input.Email, input.Message);

            var id= await _contactUsRepository.InsertAndGetIdAsync(contact);

            await CurrentUnitOfWork.SaveChangesAsync();

            return id > 0;
        }

        public async Task<ListResultDto<SearchedPlaceDto>> GetMostSearchedPlacesAsync()
        {
            var places = await _searchedPlaceRepository
                .GetAll()
                .OrderByDescending(x => x.SearchCount)
                .Take(3)
                .ToListAsync();


                //.GetAll()
                //.GroupBy(x => x.PlaceName)
                //.Select(x => new { PlaceName = x.Key, Count = x.Count() })
                //.OrderByDescending(x => x.Count)
                //.Take(3)
                //.ToListAsync();

            return new ListResultDto<SearchedPlaceDto>(places.MapTo<List<SearchedPlaceDto>>());
        }
    }
}

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
        private readonly IRepository<ContactUs> _contactUsRepository;
        private readonly ISearchedPlacesManager _searchedPlacesManager;

        public HomeAppService(IRepository<ContactUs> contactUsRepository, ISearchedPlacesManager searchedPlacesManager)
        {
            _contactUsRepository = contactUsRepository;
            _searchedPlacesManager = searchedPlacesManager;

        }

        public async Task<bool> CreateContactUsAsync(ContactUsDto input)
        {
            var contact = new ContactUs(input.Name, input.Email, input.Message);

            var id= await _contactUsRepository.InsertAndGetIdAsync(contact);

            await CurrentUnitOfWork.SaveChangesAsync();

            return id > 0;
        }

        public async Task<ListResultDto<SearchedPlaceAndPhoto>> GetMostSearchedPlacesAsync()
        {

            var places = await _searchedPlacesManager.GetMostSearchedPlaces();
            
            return new ListResultDto<SearchedPlaceAndPhoto>(places.MapTo<List<SearchedPlaceAndPhoto>>());
        }
    }
}

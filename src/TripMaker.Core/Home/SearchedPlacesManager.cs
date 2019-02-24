using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Home.Models;

namespace TripMaker.Home
{
    public class SearchedPlacesManager : ISearchedPlacesManager
    {
        private readonly IRepository<SearchedPlace> _searchPlaceRepository;

        public SearchedPlacesManager(IRepository<SearchedPlace> searchPlaceRepository)
        {
            _searchPlaceRepository = searchPlaceRepository;
        }

        public async Task InsertOrUpdateAsync(string placeId, string placeName)
        {
            var searchPlace = await _searchPlaceRepository
                .GetAll()
                .Where(x => x.PlaceId == placeId && x.PlaceName == placeName)
                .FirstOrDefaultAsync();

            if (searchPlace == null)
            {
                await _searchPlaceRepository.InsertAsync(new SearchedPlace(placeId,placeName));
            }
            else
            {
                searchPlace.AddCount();
            }
        }
    }
}

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Helpers;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Home.Models;
using Abp.Domain.Repositories;
using TripMaker.PlacePhotos;

namespace TripMaker.Home
{
    public class SearchedPlacesManager : ISearchedPlacesManager
    {
        private readonly IRepository<SearchedPlace> _searchPlaceRepository;
        private readonly IRepository<PlacePhoto> _placePhotoRepository;

        private readonly IPlacePhotoManager _placePhotoManager;

        public SearchedPlacesManager(IRepository<SearchedPlace> searchPlaceRepository, IRepository<PlacePhoto> placePhotoRepository, IPlacePhotoManager placePhotoManager)
        {
            _searchPlaceRepository = searchPlaceRepository;
            _placePhotoRepository = placePhotoRepository;
            _placePhotoManager = placePhotoManager;
        }

        public async Task<ICollection<SearchedPlaceAndPhoto>> GetMostSearchedPlaces(int number = 3)
        {
            var places = await _searchPlaceRepository
                .GetAll()
                .OrderByDescending(x => x.SearchCount)
                .Take(number)
                .ToListAsync();

            var result = new List<SearchedPlaceAndPhoto>();

            foreach(var place in places)
            {
                var hasPhoto = false;
                var photo = String.Empty;

                var photoCounter = await _placePhotoRepository.CountAsync(x => x.PlaceId == place.PlaceId);
                if (photoCounter == 0)
                {
                    photo = await _placePhotoManager.UpdatePhotos(place.PlaceId);
                }
                else
                    hasPhoto = true;

                if(hasPhoto)
                {
                    Random r = new Random();
                    int skipPhotos = r.Next(photoCounter);

                    var placePhoto = (await _placePhotoRepository
                                    .GetAll()
                                    .Where(x => x.PlaceId == place.PlaceId)
                                    .OrderByDescending(x => !String.IsNullOrWhiteSpace(x.Photo))
                                    .Skip(skipPhotos)
                                    .FirstOrDefaultAsync());

                    photo = placePhoto != null ? placePhoto.Photo : String.Empty; 
                }



                result.Add(new SearchedPlaceAndPhoto(place.PlaceId, place.PlaceName, place.SearchCount, photo));
            }

            return result;
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

            if(await _placePhotoRepository.CountAsync(x=>x.PlaceId == placeId) == 0)
            {
                await _placePhotoManager.UpdatePhotos(placeId);
            }
        }

    }
}

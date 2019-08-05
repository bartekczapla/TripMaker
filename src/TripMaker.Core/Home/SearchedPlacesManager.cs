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

namespace TripMaker.Home
{
    public class SearchedPlacesManager : ISearchedPlacesManager
    {
        private readonly IRepository<SearchedPlace> _searchPlaceRepository;
        private readonly IRepository<PlacePhoto> _placePhotoRepository;
        private readonly IGooglePlaceDetailsInputFactory _googlePlaceDetailsInputFactory;
        private readonly IGooglePlacePhotosApiCaller _googlePlacePhotosApiCaller;
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient; 

        public SearchedPlacesManager(IRepository<SearchedPlace> searchPlaceRepository, IRepository<PlacePhoto> placePhotoRepository,
            IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller, IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory)
        {
            _searchPlaceRepository = searchPlaceRepository;
            _placePhotoRepository = placePhotoRepository;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceDetailsInputFactory = googlePlaceDetailsInputFactory;
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
                var photoCounter = await _placePhotoRepository.CountAsync(x => x.PlaceId == place.PlaceId);
                if (photoCounter == 0)
                {
                    hasPhoto = await UpdatePlacePhotos(place.PlaceId);
                }
                else
                    hasPhoto = true;

                Random r = new Random();
                int skipPhotos = r.Next(photoCounter);

                var photo = (await _placePhotoRepository
                                .GetAll()
                                .Where(x => x.PlaceId == place.PlaceId)
                                .OrderByDescending(x => !String.IsNullOrWhiteSpace(x.Photo))
                                .Skip(skipPhotos)
                                .FirstOrDefaultAsync());

                result.Add(new SearchedPlaceAndPhoto(place.PlaceId, place.PlaceName, place.SearchCount, photo != null ? photo.Photo : String.Empty ));
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
                await UpdatePlacePhotos(placeId);
            }
        }

        private async Task<bool> UpdatePlacePhotos(string placeId)
        {
                var details =await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreatePhotoReference(placeId));
                if (InterpreteGoogleStatus.IsStatusOk(details.status))
                {
                    var maxPhotoNum = 1;
                    foreach (var item in details.Result.photos)
                    {

                        var photo = await _googlePlacePhotosApiCaller.GetPhotoAsync(item.photo_reference,800,null);
                        if(!String.IsNullOrWhiteSpace(photo))
                        {
                            await _placePhotoRepository.InsertAsync(new PlacePhoto(placeId, item.photo_reference, photo));
                        }
                        maxPhotoNum += 1;
                        if (maxPhotoNum == 5) break;
                    }

                    return maxPhotoNum > 1;

                } else
                {
                    return false;
                } 
                
        }
    }
}

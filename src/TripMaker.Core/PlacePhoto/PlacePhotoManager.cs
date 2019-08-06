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


namespace TripMaker.PlacePhotos
{
    public class PlacePhotoManager : IPlacePhotoManager
    {
        private readonly IRepository<PlacePhoto> _placePhotoRepository;
        private readonly IGooglePlaceDetailsInputFactory _googlePlaceDetailsInputFactory;
        private readonly IGooglePlacePhotosApiCaller _googlePlacePhotosApiCaller;
        private readonly IGooglePlaceDetailsApiClient _googlePlaceDetailsApiClient;

        public PlacePhotoManager(IRepository<SearchedPlace> searchPlaceRepository, IRepository<PlacePhoto> placePhotoRepository,
            IGooglePlacePhotosApiCaller googlePlacePhotosApiCaller, IGooglePlaceDetailsApiClient googlePlaceDetailsApiClient,
            IGooglePlaceDetailsInputFactory googlePlaceDetailsInputFactory)
        {
            _placePhotoRepository = placePhotoRepository;
            _googlePlacePhotosApiCaller = googlePlacePhotosApiCaller;
            _googlePlaceDetailsApiClient = googlePlaceDetailsApiClient;
            _googlePlaceDetailsInputFactory = googlePlaceDetailsInputFactory;
        }

        public async Task<string> GetPhotos(string placeId)
        {
            if (String.IsNullOrWhiteSpace(placeId))
                return String.Empty;

            var photoCounter = await _placePhotoRepository.CountAsync(x => x.PlaceId == placeId);
            if (photoCounter == 0)
            {
                var photo = await UpdatePhotos(placeId, 1);
                return photo;
            }
            else
            {
                Random r = new Random();
                int skipPhotos = r.Next(photoCounter);

                var placePhoto = (await _placePhotoRepository
                                .GetAll()
                                .Where(x => x.PlaceId == placeId)
                                .OrderByDescending(x => !String.IsNullOrWhiteSpace(x.Photo))
                                .Skip(skipPhotos)
                                .FirstOrDefaultAsync());

                return placePhoto != null ? placePhoto.Photo : String.Empty;
            }        
        }

        public async Task<string> UpdatePhotos(string placeId, int count = 2)
        {
            var details = await _googlePlaceDetailsApiClient.GetAsync(_googlePlaceDetailsInputFactory.CreatePhotoReference(placeId));
            if (InterpreteGoogleStatus.IsStatusOk(details.status))
            {
                var maxPhotoNum = 1;
                var photo = String.Empty;
                foreach (var item in details.Result.photos)
                {

                    photo = await _googlePlacePhotosApiCaller.GetPhotoAsync(item.photo_reference, 600, null);
                    if (!String.IsNullOrWhiteSpace(photo))
                    {
                        await _placePhotoRepository.InsertAsync(new PlacePhoto(placeId, item.photo_reference, photo));
                    }
                    maxPhotoNum += 1;
                    if (maxPhotoNum >= count) break;
                }

                return photo;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}

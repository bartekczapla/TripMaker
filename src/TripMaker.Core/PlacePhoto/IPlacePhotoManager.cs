using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripMaker.PlacePhotos
{
    public interface IPlacePhotoManager : IDomainService
    {
        Task<string> UpdatePhotos(string placeId, int count = 1);

        Task<string> GetPhotos(string placeId);
    }
}

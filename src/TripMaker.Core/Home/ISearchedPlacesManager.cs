using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Home.Models;

namespace TripMaker.Home
{
    public interface ISearchedPlacesManager : IDomainService
    {
        Task InsertOrUpdateAsync(string placeId, string placeName);

        Task<ICollection<SearchedPlaceAndPhoto>> GetMostSearchedPlaces(int number = 3);
    }
}

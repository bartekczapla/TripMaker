using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Home.Models
{
    public class SearchedPlaceAndPhoto
    {
        public string PlaceId { get; protected set; }

        public string PlaceName { get; protected set; }

        public int SearchCount { get; protected set; }

        public string Photo { get; protected set; }

        public SearchedPlaceAndPhoto(string placeId, string placeName, int count, string photo)
        {
            PlaceId = placeId;
            PlaceName = placeName;
            SearchCount = count;
            Photo = photo;
        }
    }
}

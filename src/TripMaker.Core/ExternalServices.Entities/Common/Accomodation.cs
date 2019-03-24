using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.Common
{
    public class Accomodation
    {
        public Accomodation(Location location, string placeId, string placeName, string formattedAddress)
        {
            Location = new Location
            {
                lat = location.lat,
                lng = location.lng
            };

            PlaceId = placeId;

            PlaceName = placeName;

            FormattedAddress = formattedAddress;
        }

        public Location Location { get; set; }

        public string PlaceId { get; set; }

        public string PlaceName { get; set; }

        public string FormattedAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.Common
{
    public class Accomodation
    {
        public Accomodation(Location location, string placeId)
        {
            Location = new Location
            {
                lat = location.lat,
                lng = location.lng
            };

            PlaceId = placeId;
        }

        public Location Location { get; set; }

        public string PlaceId { get; set; }
    }
}

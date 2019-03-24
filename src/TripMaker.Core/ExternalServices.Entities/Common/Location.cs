using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.Common
{
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }

        public static Location Create(double lat, double lng)
        {
            return new Location
            {
                lat = lat,
                lng = lng
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Entities.GoogleDirections
{
    public class GoogleDirectionsInput
    {
        public GoogleDirectionsInput(Location originLoc, Location destinationLoc, GoogleTravelMode mode, LanguageType language, int? departure_time = null)
        {
            OriginLoc = originLoc;
            DestinationLoc = destinationLoc;
            Mode = mode;
            Units = "metric";
            Departure_time = departure_time;
            WaypointsLoc = new List<Location>();
            WaypointsPlaceId = new List<string>();
        }

        public GoogleDirectionsInput(string originPlaceId, string destinationPlaceId, GoogleTravelMode mode, LanguageType language, int? departure_time=null)
        {
            OriginPlaceId = originPlaceId;
            DestinationPlaceId = destinationPlaceId;
            Language = language;
            Mode = mode;
            Units = "metric";
            Departure_time = departure_time;
            WaypointsLoc = new List<Location>();
            WaypointsPlaceId = new List<string>();
        }

        public Location OriginLoc { get; set; }
        public string OriginPlaceId { get; set; }
        public Location DestinationLoc { get; set; }
        public string DestinationPlaceId { get; set; }
        public GoogleTravelMode Mode { get; set; }
        public GoogleRestrictions Restrictions { get; set; }
        public LanguageType Language { get; set; }
        public string Units { get; set; }
        public int? Departure_time { get; set; }
        public TransitRoutingPreference TransitRouting { get; set; } // only to transit
        public IList<Location> WaypointsLoc { get; set; }
        public IList<string> WaypointsPlaceId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.ExternalServices.Entities.GoogleDistanceMatrix
{
    public class GoogleDistanceMatrixInput
    {

        public GoogleDistanceMatrixInput()
        {
            Units= "metric";
            OriginsLoc = new List<Location>();
            OriginsPlaceId = new List<string>();
            DestinationsLoc = new List<Location>();
            DestinationsPlaceId = new List<string>();
        }

        public GoogleDistanceMatrixInput(LanguageType language,GoogleTravelMode mode = GoogleTravelMode.Walking,int? departure_time=null)
        {
            Language = language;
            Mode = mode;
            Units = "metric";
            Departure_time = departure_time;
            OriginsLoc = new List<Location>();
            OriginsPlaceId = new List<string>();
            DestinationsLoc = new List<Location>();
            DestinationsPlaceId = new List<string>();
        }

        public IList<Location> OriginsLoc {get; set; }
        public IList<string> OriginsPlaceId { get; set; }
        public IList<Location> DestinationsLoc { get; set; }
        public IList<string> DestinationsPlaceId { get; set; }

        public LanguageType Language { get; set; }
        public GoogleTravelMode Mode { get; set; }
        public GoogleRestrictions Restrictions { get; set; }
        public string Units { get; set; }
        //public int? Arrival_time { get; set; }
        public int? Departure_time { get; set; }
        public TransitRoutingPreference TransitRouting { get; set; }
    }
}

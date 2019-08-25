using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Helpers;

namespace TripMaker.ExternalServices.Entities.GoogleDirections
{
    public class GoogleDirectionsRootObject
    {
        public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public List<Route> routes { get; set; }
        public string status { get; set; }
        public string inputUri { get; set; }
        public string resultJson { get; set; }

        public bool IsOk
        {
            get
            {
                return InterpreteGoogleStatus.Interprete(status) == Enums.GoogleResultStatus.OK;
            }
        }
    }
}

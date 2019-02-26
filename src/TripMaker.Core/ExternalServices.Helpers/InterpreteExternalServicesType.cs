using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Helpers
{
    public static class InterpreteExternalServicesType
    {
        public static string Interprete(ExternalServicesType type)
        {
            switch (type)
            {
                case ExternalServicesType.GooglePlaceDetails:
                    return "GooglePlaceDetails";
                case ExternalServicesType.GooglePlaceSearch:
                    return "GooglePlaceSearch";
                case ExternalServicesType.GooglePlaceNearbySearch:
                    return "GooglePlaceNearbySearch";
                case ExternalServicesType.GoogleDistanceMatrix:
                    return "GoogleDistanceMatrix";
                case ExternalServicesType.GoogleDirections:
                    return "GoogleDirections";
                default:
                    return String.Empty;
            }
        }
    }
}

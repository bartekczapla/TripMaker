using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Helpers
{
    public static class InterpreteEnums
    {
        public static GoogleTravelMode InterpreteTravelMode(string mode)
        {
            var lowerCaseMode = mode.ToLowerInvariant();
            switch (lowerCaseMode)
            {
                case "driving":
                    return GoogleTravelMode.Driving;
                case "walking":
                    return GoogleTravelMode.Walking;
                case "bicycling":
                    return GoogleTravelMode.Bicycling;
                case "transit":
                    return GoogleTravelMode.Transit;
                default:
                    return GoogleTravelMode.Driving;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using GeoCoordinatePortable;

namespace TripMaker.Plan
{
    public static class PlanHelpers
    {
        public static double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
        {
            var cord1 = new GeoCoordinate(lat1, lng1);
            var cord2 = new GeoCoordinate(lat2, lng2);

            return cord1.GetDistanceTo(cord2);
        }
    }
}

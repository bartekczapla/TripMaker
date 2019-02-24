using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.Common;
using System.Linq;

namespace TripMaker.ExternalServices.Helpers
{
    public static class GooglePlaceCommon
    {
        public static void EncodeString(ref string input)
        {
            input.Replace("%", "%25");
            input.Replace(" ", "%20");
            input.Replace("\"", "%22");
            input.Replace("?", "%3F");
            input.Replace(",", "%2C");
            input.Replace("<", "%3C");
            input.Replace("<", "%3E");
            input.Replace("#", "%23");
            input.Replace("|", "%7C");
        }

        public static string ConvertLocationsToString(IList<Location> locations)
        {
            var result = String.Join("|", locations.Select(x => $"{x.lat},{x.lng}").ToArray());
            return result;
        }

        public static string ConvertPlaceIdsToString(IList<string> locationIds)
        {
            var result = String.Join("|", locationIds.Select(x => $"place_id:{x}").ToArray());
            return result;
        }
    }
}

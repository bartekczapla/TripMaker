using System;
using System.Collections.Generic;
using System.Text;

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
    }
}

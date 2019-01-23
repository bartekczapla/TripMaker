using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Helpers
{
    public static class GooglePlaceCommon
    {
        public static string ReplaceSpace(ref string input)
        {
            return input.Replace(" ", "%20");
        }
    }
}

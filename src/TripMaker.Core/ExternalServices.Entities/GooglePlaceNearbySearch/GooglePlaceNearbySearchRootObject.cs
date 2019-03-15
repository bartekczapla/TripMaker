using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch
{
    public class GooglePlaceNearbySearchRootObject
    {
        public List<object> html_attributions { get; set; }
        public List<GooglePlaceNearbySearchResult> results { get; set; }
        public string status { get; set; }
        public string resultJson { get; set; }
        public string inputUri { get; set; }

    }
}

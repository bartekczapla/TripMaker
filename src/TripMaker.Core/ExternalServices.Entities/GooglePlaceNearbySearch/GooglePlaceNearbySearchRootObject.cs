using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Helpers;

namespace TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch
{
    public class GooglePlaceNearbySearchRootObject
    {
        public List<object> html_attributions { get; set; }
        public string next_page_token { get; set; }
        public List<GooglePlaceNearbySearchResult> results { get; set; }
        public string status { get; set; }
        public string resultJson { get; set; }
        public string inputUri { get; set; }
        public bool IsOk
        {
            get
            {
                return InterpreteGoogleStatus.Interprete(status) == Enums.GoogleResultStatus.OK;
            }
        }
        public bool IsMoreResults
        {
            get
            {
                return !String.IsNullOrWhiteSpace(next_page_token);
            }
        }
    }
}

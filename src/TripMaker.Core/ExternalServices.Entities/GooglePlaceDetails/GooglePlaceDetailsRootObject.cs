using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceDetails
{
    public class GooglePlaceDetailsRootObject
    {
        public List<object> html_attributions { get; set; }

        [JsonProperty("result")]
        public GooglePlaceDetailsResult Result { get; set; }

        public string status { get; set; }

        public string resultJson { get; set; }
    }
}

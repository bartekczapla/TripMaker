using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Helpers;

namespace TripMaker.ExternalServices.Entities.GooglePlaceDetails
{
    public class GooglePlaceDetailsRootObject
    {
        public List<object> html_attributions { get; set; }

        [JsonProperty("result")]
        public GooglePlaceDetailsResult Result { get; set; }

        public string status { get; set; }

        public string inputUri { get; set; }

        public string resultJson { get; set; }

        public bool IsOk
        {
            get
            {
                if (InterpreteGoogleStatus.Interprete(status) != Enums.GoogleResultStatus.OK)
                    return false;

                if (Result == null)
                    return false;

                if(Result.geometry == null || Result.geometry.location == null)
                    return false;

                return true;
            }
        }
    }
}

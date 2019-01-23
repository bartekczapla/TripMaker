using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceSearch
{
    public class GooglePlaceSearchRootObject
    {
        public List<Candidate> candidates { get; set; }
        public string status { get; set; }
    }
}

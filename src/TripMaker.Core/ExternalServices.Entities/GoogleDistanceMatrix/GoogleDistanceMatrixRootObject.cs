using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GoogleDistanceMatrix
{
    public class GoogleDistanceMatrixRootObject
    {
        public string status { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<string> destination_addresses { get; set; }
        public List<GoogleDistanceRow> rows { get; set; }
        public string inputUri { get; set; }
        public string resultJson { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GoogleDistanceMatrix
{
    public class Element
    {
        public string status { get; set; }
        public Duration duration { get; set; }
        public Distance distance { get; set; }
        public Fare fare { get; set; }
    }

}

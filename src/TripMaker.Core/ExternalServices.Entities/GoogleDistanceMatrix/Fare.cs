using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GoogleDistanceMatrix
{
    public class Fare
    {
        public string currency { get; set; }
        public int value { get; set; }
        public string text { get; set; }
    }
}

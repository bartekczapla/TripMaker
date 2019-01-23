using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceSearch
{
    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.ExternalServices.Entities.GoogleDirections
{
    public class Bounds
    {
        public Location northeast { get; set; }
        public Location southwest { get; set; }
    }
}

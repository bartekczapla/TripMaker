﻿using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.ExternalServices.Entities.GooglePlaceDetails
{
    public class Geometry
    {
            public Location location { get; set; }
            public Viewport viewport { get; set; }
    }
}

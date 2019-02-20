﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GoogleDirections
{
    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public Location end_location { get; set; }
        public string start_address { get; set; }
        public Location start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> traffic_speed_entry { get; set; }
        public List<object> via_waypoint { get; set; }
    }
}

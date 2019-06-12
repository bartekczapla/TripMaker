using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanRouteStep))]
    public class PlanRouteStepDto
    {
        public int Distance { get; set; } //meters

        public int Duration { get; set; } //seconds

        public double StartStepLat { get; set; }

        public double StartStepLng { get; set; }

        public double EndStepLat { get; set; }

        public double EndStepLng { get; set; }

        public string HtmlInstruction { get; set; }

        public GoogleTravelMode TravelMode { get; set; }

        public string Maneuver { get; set; }
    }
}

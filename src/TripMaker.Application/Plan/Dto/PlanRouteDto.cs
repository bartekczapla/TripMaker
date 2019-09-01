using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanRoute))]
    public class PlanRouteDto
    {
        public virtual int Distance { get; set; }

        public virtual int Duration { get;  set; }

        public GoogleTravelMode TravelMode { get;  set; }

        public ICollection<PlanRouteStepDto> Steps { get; set; }

    }
}

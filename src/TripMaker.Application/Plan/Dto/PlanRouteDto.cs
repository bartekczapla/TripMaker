using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanRoute))]
    public class PlanRouteDto
    {
        public virtual int Distance { get; protected set; }

        public virtual int Duration { get; protected set; }

        public ICollection<PlanRouteStepDto> Steps { get; set; }

    }
}

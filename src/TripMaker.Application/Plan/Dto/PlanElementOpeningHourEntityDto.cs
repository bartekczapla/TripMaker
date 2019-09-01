using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanElementOpeningHourEntity))]
    public class PlanElementOpeningHourEntityDto
    {
        public int DayOpen { get; set; }
        public int? DayClose { get; set; }
        public TimeSpan Open { get; set; }
        public TimeSpan? Close { get; set; }
    }
}

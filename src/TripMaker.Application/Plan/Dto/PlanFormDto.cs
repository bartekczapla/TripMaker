using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanForm))]
    public class PlanFormDto
    {

        public string PlaceName { get; set; }

        public string PlaceId { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan? EndTime { get; set; }

        public bool HasJourneyBooked { get; set; }

        public bool HasAccomodationBooked { get; set; }

        public LanguageType Language { get; set; }

        public DateTime CreationTime { get; set; }


    }
}

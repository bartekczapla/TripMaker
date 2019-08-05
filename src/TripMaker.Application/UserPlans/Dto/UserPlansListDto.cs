using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan;

namespace TripMaker.UserPlans.Dto
{
    public class UserPlansListDto : EntityDto
    {

        public string PlaceName { get; set; }

        public string PlaceId { get; set; }

        public string Destination { get; set; }

        public int? PlanFormId { get; set; }

        public DateTime StartDate { get;  set; }

        public TimeSpan? StartTime { get;  set; }

        public DateTime EndDate { get;  set; }

        public TimeSpan? EndTime { get;  set; }

        public bool HasJourneyBooked { get; set; }

        public bool HasAccomodationBooked { get; set; }

        public virtual LanguageType Language { get; set; }

        public DateTime CreationTime { get; set; }

    }
}

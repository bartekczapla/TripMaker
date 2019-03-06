using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan
{
    [AutoMapTo(typeof(PlanForm))]
    public class GetPlanInput
    {
        [Required]
        [MaxLength(80)]
        public virtual string PlaceName { get; set; }

        [Required]
        [MaxLength(80)]
        public virtual string PlaceId { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual TimeSpan? StartTime { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual TimeSpan? EndTime { get; set; }

        public virtual bool HasJourneyBooked { get; set; }

        public virtual bool HasAccomodationBooked { get; set; }

        public virtual LanguageType Language { get;  set; }

        public override string ToString()
        {
            return string.Format("[GetPlanInput > PlaceName = {0}, StartDate = {1}]", PlaceName, StartDate);
        }
    }
}
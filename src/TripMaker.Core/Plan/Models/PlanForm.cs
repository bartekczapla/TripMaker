using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using TripMaker.Enums;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("PlanForms")]
    public class PlanForm : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 512;

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceName { get; protected set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get; protected set; }

        [GreaterThanCurrentDate]
        [DateGreaterThan("EndDate")]
        public virtual DateTime StartDate { get; protected set; }

        public virtual TimeSpan? StartTime { get; protected set; }

        [GreaterThanCurrentDate]
        public virtual DateTime EndDate { get; protected set; }

        public virtual TimeSpan? EndTime { get; protected set; }

        public virtual bool HasJourneyBooked { get; protected set; }

        public virtual bool HasAccomodationBooked { get; protected set; }

        public virtual LanguageType Language { get; protected set; }

        public virtual DateTime CreationTime { get; set; }

        protected PlanForm()
        {
            CreationTime = Clock.Now;
        }

        public PlanForm(string placeName, string placeId, DateTime startDate, TimeSpan? startTime, DateTime endDate, TimeSpan? endTime, LanguageType language, bool hasJourneyBooked = false, bool hasAccomodationBooked = false)
            :this()
        {
            PlaceName = placeName;
            PlaceId = placeId;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            Language = language;
            HasJourneyBooked = hasJourneyBooked;
            HasAccomodationBooked = hasAccomodationBooked;
        }

        public bool IsDatesCorrect()
        {
            return DateTime.Compare(StartDate, Clock.Now) >= 0 && DateTime.Compare(StartDate, EndDate) <= 0;
        }
    }
}

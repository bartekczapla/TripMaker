using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("Plans")]
    public class Plan : Entity
    {
        [Required]
        [MaxLength(80)]
        public virtual string PlaceName { get; protected set; }

        [Required]
        [MaxLength(80)]
        public virtual string PlaceId { get; protected set; }

        [GreaterThanCurrentDate]
        [DateGreaterThan("EndDate")]
        public virtual DateTime StartDate { get; protected set; }

        [GreaterThanCurrentDate]
        public virtual DateTime EndDate { get; protected set; }

        public virtual bool HasJourneyBooked { get; protected set; }

        public virtual bool HasAccomodationBooked { get; protected set; }

        protected Plan() { }

        public Plan(string placeName, string placeId, DateTime startDate, DateTime endDate, bool hasJourneyBooked=false, bool hasAccomodationBooked=false)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            StartDate = startDate;
            EndDate = endDate;
            HasJourneyBooked = hasJourneyBooked;
            HasAccomodationBooked = hasAccomodationBooked;
        }

    }
}



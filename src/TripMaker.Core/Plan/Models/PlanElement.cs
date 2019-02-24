using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("PlanElements")]
    public class PlanElement : Entity
    {
        public const int MaxTitleLength = 128;

        [MaxLength(MaxTitleLength)]
        public virtual string PlaceName { get; protected set; }


        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; protected set; }
        public virtual int PlanId { get; protected set; }

        public PlanElement(string placeName, int planId)
        {
            PlaceName = placeName;
            PlanId = planId;

        }

    }
}

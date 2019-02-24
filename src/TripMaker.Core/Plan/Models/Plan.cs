using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("Plans")]
    public class Plan : Entity
    {
        public const int MaxTitleLength = 128;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Destination { get; protected set; }

        [ForeignKey("PlanFormId")]
        public virtual PlanForm PlanForm { get; protected set; }
        public virtual int? PlanFormId { get; protected set; }

        [ForeignKey("PlanId")]
        public virtual ICollection<PlanElement> Elements { get; protected set; }

        public Plan(string destination,int? planFormId=null)
        {
            Destination = destination;
            PlanFormId = planFormId;

            Elements = new Collection<PlanElement>();

        }

    }
}



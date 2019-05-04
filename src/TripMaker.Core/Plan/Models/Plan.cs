using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using TripMaker.Authorization.Users;
using TripMaker.Plan.Models;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("Plans")]
    public class Plan : Entity
    {
        public const int MaxTitleLength = 128;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Destination { get;  set; }

        [ForeignKey("PlanFormId")]
        public virtual PlanForm PlanForm { get;  set; }
        public virtual int? PlanFormId { get;  set; }

        [ForeignKey("UserId")]
        public virtual User User { get;  set; }
        public virtual long? UserId { get;  set; }

        [StringLength(MaxTitleLength)]
        public virtual string Comment { get;  set; }


        [ForeignKey("PlanId")]
        public virtual ICollection<PlanElement> Elements { get;  set; }

        public Plan(string destination,int? planFormId=null, long? userId=null)
        {
            Destination = destination;
            PlanFormId = planFormId;
            Comment = "test";
            UserId = userId;
            Elements = new Collection<PlanElement>();

 

        }

    }
}



using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Entities.Models
{
    [Table("ExternalServicesJSON")]
    public class ExternalServicesJSON : Entity, IHasCreationTime
    {
        public const int MaxUriLength = 64*4;
        public const int MaxJsonLength = 128*128;

        [Required]
        public virtual ExternalServicesType ServiceType { get; protected set; }

        [Required]
        [MaxLength(MaxUriLength)]
        public virtual string InputUri { get; protected set; }

        [Required]
        [MaxLength(MaxJsonLength)]
        public virtual string ResultJSON { get; protected set; }

        [ForeignKey("PlanFormId")]
        public virtual PlanForm PlanForm { get; protected set; }
        public virtual int? PlanFormId { get; protected set; }

        public virtual DateTime CreationTime { get; set; }


        protected ExternalServicesJSON()
        {
            CreationTime = Clock.Now;
        }

        public ExternalServicesJSON(ExternalServicesType type, string inputUri, string resultJson,int? planFormId=null)
            :this()
        {
            ServiceType = type;
            InputUri = inputUri;
            ResultJSON = resultJson;
            PlanFormId = planFormId;
        }
    }
}

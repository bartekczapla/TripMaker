using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Entities.Models
{
    [Table("ExternalServicesJSON")]
    public class ExternalServicesJSON : Entity, IHasCreationTime
    {
        public const int MaxTypeLength = 80;
        public const int MaxJsonLength = 64*128;

        [Required]
        [MaxLength(MaxTypeLength)]
        public virtual string ServiceType { get; protected set; }

        [Required]
        [MaxLength(MaxJsonLength)]
        public virtual string InputJSON { get; protected set; }

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

        public ExternalServicesJSON(string type, string inputJson, string resultJson,int? planFormId=null)
            :this()
        {
            ServiceType = type;
            InputJSON = inputJson;
            ResultJSON = resultJson;
            PlanFormId = planFormId;
        }
    }
}

using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    [Table("PlanElementyTypeEntities")]
    public class PlanElementyTypeEntity : Entity
    {
        public virtual PlanElementType ElementType { get; set; }

        [ForeignKey("PlanElementId")]
        public virtual PlanElement PlanElement { get; protected set; }
        public virtual int PlanElementId { get; protected set; }

        public PlanElementyTypeEntity(PlanElementType elementType)
        {
            ElementType = elementType;
        }
    }
}

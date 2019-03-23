using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TripMaker.Plan.Models
{
    [Table("PlanRoutes")]
    public class PlanRoute : Entity
    {
        public virtual int Distance { get; protected set; }

        public virtual int Duration { get; protected set; }

        [ForeignKey("StartPlanElementId")]
        public virtual PlanElement StartPlanElement { get; protected set; }
        public virtual int? StartPlanElementId { get; protected set; }

        [ForeignKey("EndPlanElementId")]
        public virtual PlanElement EndPlanElement { get; protected set; }
        public virtual int? EndPlanElementId { get; protected set; }


        [ForeignKey("PlanRouteId")]
        public virtual ICollection<PlanRouteStep> Steps { get; protected set; }

        public PlanRoute( int distance, int duration,int? startPlanElementId=null,int? endPlanElementId=null )
        {
            StartPlanElementId = startPlanElementId;
            EndPlanElementId = endPlanElementId;
            Distance = distance;
            Duration = duration;
            Steps = new Collection<PlanRouteStep>();
        }

    }
}

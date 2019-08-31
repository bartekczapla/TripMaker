using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    [Table("PlanRoutes")]
    public class PlanRoute : Entity
    {
        public virtual int Distance { get; protected set; } //meters

        public virtual int Duration { get; protected set; } //seconds

        public virtual GoogleTravelMode TravelMode { get; protected set; }

        //[ForeignKey("StartPlanElementId")]
        //public virtual PlanElement StartPlanElement { get; protected set; }
        //public virtual int? StartPlanElementId { get; protected set; }

        //[ForeignKey("EndingRouteId")]
        //public virtual PlanElement EndPlanElement { get; protected set; }
        //public virtual int? EndPlanElementId { get; protected set; }

        //string copywright?

        [ForeignKey("PlanRouteId")]
        public virtual ICollection<PlanRouteStep> Steps { get; protected set; }

        public PlanRoute( int distance, int duration, GoogleTravelMode travelMode)
        {
            Distance = distance;
            Duration = duration;
            TravelMode = travelMode;
            Steps = new Collection<PlanRouteStep>();
        }

        [NotMapped]
        public TimeSpan TimeDuration
        {
            get
            {
                return TimeSpan.FromSeconds(Duration);
            }
        }

    }
}

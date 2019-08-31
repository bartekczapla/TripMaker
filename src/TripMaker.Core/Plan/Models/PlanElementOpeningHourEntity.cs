using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{

    [Table("PlanElementOpeningHourEntityEntities")]
    public class PlanElementOpeningHourEntity : Entity
    {
        public virtual int DayOpen { get; set; }
        public virtual int? DayClose { get; set; }
        public virtual TimeSpan Open { get; set; }
        public virtual TimeSpan? Close { get; set; }

        [ForeignKey("PlanElementId")]
        public virtual PlanElement PlanElement { get; protected set; }
        public virtual int PlanElementId { get; protected set; }

        private PlanElementOpeningHourEntity(int dayOpen, int? dayClose, TimeSpan open, TimeSpan? close)
        {
            DayOpen = dayOpen;
            DayClose = dayClose;
            Open = open;
            Close = close;
        }

        public PlanElementOpeningHourEntity(PlanElementOpeningHours item)
            :this(item.DayOpen, item.DayClose, item.Open, item.Close)
        {

        }
    }
}

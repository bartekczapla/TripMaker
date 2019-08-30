using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Plan.Models
{
    public class PlanElementOpeningHours
    {
        public PlanElementOpeningHours(int dayOpen,int? dayClose, TimeSpan open, TimeSpan? close)
        {
            DayOpen = dayOpen;
            DayClose = dayClose;
            Open = open;
            Close = close;
        }

        public int DayOpen { get; set; }
        public int? DayClose { get; set; }
        public TimeSpan Open { get; set; }
        public TimeSpan? Close { get; set; }
    }
}

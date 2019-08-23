using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Plan
{
    public abstract class PlanElementsAssumptions
    {
        public readonly TimeSpan StartTimeAssumption = new TimeSpan(8, 0, 0);
        public readonly TimeSpan EndTimeAssumption = new TimeSpan(20, 0, 0);
        public readonly TimeSpan OneHour = new TimeSpan(1, 0, 0);
        public readonly TimeSpan SleepingDuration = new TimeSpan(8, 0, 0);

        //Eating
        public readonly TimeSpan LunchTime = new TimeSpan(14, 0, 0);
        public readonly TimeSpan DinnerTime = new TimeSpan(18, 0, 0);
        public readonly TimeSpan PartyTime = new TimeSpan(19, 0, 0);
        public readonly TimeSpan SleepingTime = new TimeSpan(23, 0, 0);
        public readonly TimeSpan SleepingTime2 = new TimeSpan(5, 0, 0);

        //PlanElement Duration
        public readonly TimeSpan EatingDuration = new TimeSpan(1, 0, 0);
        public readonly TimeSpan EntertainmentDuration = new TimeSpan(3, 0, 0);
        public readonly TimeSpan RelaxDuration = new TimeSpan(3, 0, 0);
        public readonly TimeSpan ActivityDuration = new TimeSpan(2, 0, 0);
        public readonly TimeSpan CultureDuration = new TimeSpan(3, 0, 0);
        public readonly TimeSpan SightseeingDuration = new TimeSpan(3, 0, 0);
        public readonly TimeSpan PartyingDuration = new TimeSpan(3, 0, 0);
        public readonly TimeSpan ShoppingDuration = new TimeSpan(2, 0, 0);

        public readonly TimeSpan DoingNothingTime = new TimeSpan(0, 10, 0);
    }
}

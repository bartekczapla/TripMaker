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
        public readonly TimeSpan SleepingTime = new TimeSpan(8, 0, 0);
    }
}

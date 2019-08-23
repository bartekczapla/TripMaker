using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanElementDecisionMaker : PlanElementsAssumptions, IPlanElementDecisionMaker
    {
        public PlanElementDecision Decide(DateTime currentDateTime, IList<PlanElement> currentDayElements)
        {
            var currentTime = currentDateTime.TimeOfDay;

            if(TimeSpan.Compare(currentTime, SleepingTime) >= 0 || TimeSpan.Compare(currentTime, SleepingTime2) < 0)
            {
                return new PlanElementDecision(PlanElementType.Sleeping);
            }

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Eating))
                return new PlanElementDecision(PlanElementType.Eating); //first thing- breakfast

            if (TimeSpan.Compare(currentTime, LunchTime) >= 0 && currentDayElements.Where(x=>x.ElementType==PlanElementType.Eating).Count() ==1)
                return new PlanElementDecision(PlanElementType.Eating); //lunch

            if (TimeSpan.Compare(currentTime, DinnerTime) >= 0 && currentDayElements.Where(x => x.ElementType == PlanElementType.Eating).Count() == 2)
                return new PlanElementDecision(PlanElementType.Eating); //dinner


            //var group = currentDayElements.GroupBy(x => x.ElementType);
            if(!currentDayElements.Any(x=>x.ElementType==PlanElementType.Activity))
                return new PlanElementDecision(PlanElementType.Activity);

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Culture))
                return new PlanElementDecision(PlanElementType.Culture);

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Entertainment))
                return new PlanElementDecision(PlanElementType.Entertainment);

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Relax))
                return new PlanElementDecision(PlanElementType.Relax);

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Shopping))
                return new PlanElementDecision(PlanElementType.Shopping);

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Sightseeing))
                return new PlanElementDecision(PlanElementType.Sightseeing);

            if (!currentDayElements.Any(x => x.ElementType == PlanElementType.Partying) && TimeSpan.Compare(currentTime, PartyTime) >= 0)
                return new PlanElementDecision(PlanElementType.Partying);

            return new PlanElementDecision(PlanElementType.Culture);
        }

    }
}

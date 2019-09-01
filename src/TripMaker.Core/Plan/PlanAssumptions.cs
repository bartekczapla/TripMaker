using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TripMaker.Plan
{
    public class PlanAssumptions
    {
        public TimeSpan LunchTime { get; protected set; }
        public TimeSpan DinnerTime { get; protected set; }
        public TimeSpan SleepDuration { get; protected set; }
        public TimeSpan SleepingTime { get; protected set; }

        public TimeSpan EatingDuration { get; protected set; }
        public TimeSpan PlanElementDuration { get; protected set; }
        public int NumberOfMealsPerDay = 3;
        public int RadiusSearch { get; protected set; }
        public int AssumedNumberOfElement { get; protected set; }

        public PlanAssumptions(PlanForm planForm)
        {
            SleepDuration = new TimeSpan(planForm.AverageSleep, 0, 0);
            var numberOfPartyActivity = planForm.PreferedPlanElements.Count(x => x == Enums.PlanElementType.Partying) + (planForm.SortedPlanElements.IndexOf(Enums.PlanElementType.Partying) < 3 ? 1 : 0);
            switch(numberOfPartyActivity)
            {
                case 1:
                    SleepingTime = new TimeSpan(0, 0, 0);
                    break;
                case 2:
                    SleepingTime = new TimeSpan(1, 0, 0);
                    break;
                case 3:
                    SleepingTime = new TimeSpan(2, 0, 0);
                    break;
                default:
                    SleepingTime = new TimeSpan(23, 0, 0);
                    break;
            }

            LunchTime = new TimeSpan(14,0,0);
            DinnerTime = new TimeSpan(19, 0, 0);

            if(planForm.AtractionDurationPreference == Enums.PlanFormEnums.AtractionDurationPreference.Fast)
            {
                EatingDuration = new TimeSpan(1, 0, 0);
                PlanElementDuration = new TimeSpan(1, 30, 0);

            } else if (planForm.AtractionDurationPreference == Enums.PlanFormEnums.AtractionDurationPreference.Medium)
            {
                EatingDuration = new TimeSpan(1, 30, 0);
                PlanElementDuration = new TimeSpan(2, 30, 0);
            }
            else if (planForm.AtractionDurationPreference == Enums.PlanFormEnums.AtractionDurationPreference.Slow)
            {
                EatingDuration = new TimeSpan(2, 0, 0);
                PlanElementDuration = new TimeSpan(3, 30, 0);
            }

            //radius search
            var hasVehicleTransport = planForm.PreferedTravelModes.Contains(Enums.GoogleTravelMode.Driving) || planForm.PreferedTravelModes.Contains(Enums.GoogleTravelMode.Transit);
            if (hasVehicleTransport)
                RadiusSearch = 15000;
            else
                RadiusSearch = 6000;

            //numbersOfElements
            var subTimeSpan = planForm.EndDateTime.Subtract(planForm.StartDateTime);
            var subHours = subTimeSpan.Days*24 + subTimeSpan.Hours;
            var numberOfDays = (planForm.EndDateTime.DayOfYear - planForm.StartDateTime.DayOfYear+1);
            subHours -= (numberOfDays - 1) * planForm.AverageSleep; // odejmujemy czas na spanie
            var eatingHours = EatingDuration.Multiply(NumberOfMealsPerDay * numberOfDays).Days*24+EatingDuration.Multiply(NumberOfMealsPerDay * numberOfDays).Hours;
            subHours -= eatingHours; // odejmujemy czas na jedzenie
            decimal hoursPerPlanElement = PlanElementDuration.Hours;// ((decimal)PlanElementDuration.Minutes / 60);
            if (PlanElementDuration.Minutes > 0) hoursPerPlanElement += 0.5m;
            //Assume that moving is about 10% of plan
            subHours -= (int)(0.1m * (decimal)subHours);

            var assumedNumberOfElements = (int)((decimal)subHours / hoursPerPlanElement);
            AssumedNumberOfElement = assumedNumberOfElements;
        }

        public bool IsSleepAfterMidnight
        {
            get 
            {
                return TimeSpan.Compare(SleepingTime, new TimeSpan(0,0,0))>=0 && TimeSpan.Compare(SleepingTime,new TimeSpan(4,30,0))<0;
            }
        }
    }
}

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

        //PlanElement Duration
        public TimeSpan EatingDuration { get; protected set; }
        public TimeSpan EntertainmentDuration { get; protected set; }
        public TimeSpan RelaxDuration { get; protected set; }
        public TimeSpan ActivityDuration { get; protected set; }
        public TimeSpan CultureDuration { get; protected set; }
        public TimeSpan SightseeingDuration { get; protected set; }
        public TimeSpan PartyingDuration { get; protected set; }
        public TimeSpan ShoppingDuration { get; protected set; }

        public int RadiusSearch { get; protected set; }

        public PlanAssumptions(PlanForm planForm)
        {
            SleepDuration = new TimeSpan(planForm.AverageSleep, 0, 0);
            var numberOfPartyActivity = planForm.PreferedPlanElements.Count(x => x == Enums.PlanElementType.Partying) + (planForm.SortedPlanElements.IndexOf(Enums.PlanElementType.Partying) < 3 ? 1 : 0);
            switch(numberOfPartyActivity)
            {
                case 1:
                    SleepingTime = new TimeSpan(24, 0, 0);
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
                EntertainmentDuration = new TimeSpan(1, 30, 0);
                RelaxDuration = new TimeSpan(1, 30, 0);
                ActivityDuration = new TimeSpan(1, 30, 0);
                CultureDuration = new TimeSpan(1, 30, 0);
                SightseeingDuration = new TimeSpan(1, 30, 0);
                PartyingDuration = new TimeSpan(1, 30, 0);
                ShoppingDuration = new TimeSpan(1, 30, 0);
            } else if (planForm.AtractionDurationPreference == Enums.PlanFormEnums.AtractionDurationPreference.Medium)
            {
                EatingDuration = new TimeSpan(1, 30, 0);
                EntertainmentDuration = new TimeSpan(2, 30, 0);
                RelaxDuration = new TimeSpan(2, 30, 0);
                ActivityDuration = new TimeSpan(2, 30, 0);
                CultureDuration = new TimeSpan(2, 30, 0);
                SightseeingDuration = new TimeSpan(2, 30, 0);
                PartyingDuration = new TimeSpan(2, 30, 0);
                ShoppingDuration = new TimeSpan(2, 30, 0);
            }
            else if (planForm.AtractionDurationPreference == Enums.PlanFormEnums.AtractionDurationPreference.Slow)
            {
                EatingDuration = new TimeSpan(2, 0, 0);
                EntertainmentDuration = new TimeSpan(3, 30, 0);
                RelaxDuration = new TimeSpan(3, 30, 0);
                ActivityDuration = new TimeSpan(3, 30, 0);
                CultureDuration = new TimeSpan(3, 30, 0);
                SightseeingDuration = new TimeSpan(3, 30, 0);
                PartyingDuration = new TimeSpan(3, 30, 0);
                ShoppingDuration = new TimeSpan(3, 30, 0);
            }

            //radius search
            var hasVehicleTransport = planForm.PreferedTravelModes.Contains(Enums.GoogleTravelMode.Driving) || planForm.PreferedTravelModes.Contains(Enums.GoogleTravelMode.Transit);
            if (hasVehicleTransport)
                RadiusSearch = 15000;
            else
                RadiusSearch = 6000;
        }
    }
}

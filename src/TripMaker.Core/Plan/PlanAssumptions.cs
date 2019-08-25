using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public abstract class PlanAssumptions
    {
        public int NumberOfColumns => Enum.GetNames(typeof(WeightVectorLabel)).Length;

        //0. Price //1. Rating //2. Distance //3. Popularity //4.Entertainment //5. Relax //6. Activity //7. Culture //8. Sightseeing //9. Partying //10. Shopping
        public readonly Criteria[] DecisionCriterias = new Criteria[]
        {
            new Criteria{Position=(int)WeightVectorLabel.Price,
                         Label =WeightVectorLabel.Price.ToString(),
                         AspirationLevel =0.0m,
                         ReserveLevel =4.0m },

            new Criteria{Position=(int)WeightVectorLabel.Rating,
                        Label =WeightVectorLabel.Rating.ToString(),
                        AspirationLevel =5.0m,
                        ReserveLevel =1.0m},

            new Criteria{Position=(int)WeightVectorLabel.Distance,
                        Label =WeightVectorLabel.Distance.ToString(),
                        AspirationLevel =0.0m,
                        ReserveLevel =200.0m},

            new Criteria{Position=(int)WeightVectorLabel.Popularity,
                        Label =WeightVectorLabel.Popularity.ToString(),
                        AspirationLevel =20000.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Entertainment,
                        Label =WeightVectorLabel.Entertainment.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Relax,
                        Label =WeightVectorLabel.Relax.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Activity,
                        Label =WeightVectorLabel.Activity.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Culture,
                        Label =WeightVectorLabel.Culture.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Sightseeing,
                        Label =WeightVectorLabel.Sightseeing.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Partying,
                        Label =WeightVectorLabel.Partying.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},

            new Criteria{Position=(int)WeightVectorLabel.Shopping,
                        Label =WeightVectorLabel.Shopping.ToString(),
                        AspirationLevel =1.0m,
                        ReserveLevel =0.0m},
        };

        public static readonly TimeSpan StartTimeAssumption = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan EndTimeAssumption = new TimeSpan(20, 0, 0);
        public static readonly TimeSpan OneHour = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan SleepingDuration = new TimeSpan(8, 0, 0);

        public static readonly double MaximumDistanceToAccomodation = 15000;

        //Eating
        public static readonly TimeSpan LunchTime = new TimeSpan(14, 0, 0);
        public static readonly TimeSpan DinnerTime = new TimeSpan(18, 0, 0);
        public static readonly TimeSpan PartyTime = new TimeSpan(19, 0, 0);
        public static readonly TimeSpan SleepingTime = new TimeSpan(23, 0, 0);
        public static readonly TimeSpan SleepingTime2 = new TimeSpan(5, 0, 0);

        //PlanElement Duration
        public static readonly TimeSpan EatingDuration = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan EntertainmentDuration = new TimeSpan(3, 0, 0);
        public static readonly TimeSpan RelaxDuration = new TimeSpan(3, 0, 0);
        public static readonly TimeSpan ActivityDuration = new TimeSpan(2, 0, 0);
        public static readonly TimeSpan CultureDuration = new TimeSpan(3, 0, 0);
        public static readonly TimeSpan SightseeingDuration = new TimeSpan(3, 0, 0);
        public static readonly TimeSpan PartyingDuration = new TimeSpan(3, 0, 0);
        public static readonly TimeSpan ShoppingDuration = new TimeSpan(2, 0, 0);

        public static readonly TimeSpan DoingNothingTime = new TimeSpan(0, 10, 0);
    }
}

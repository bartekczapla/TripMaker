using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanInputFactory
    {
        public static PlanForm CreateTestInput()
        {
            return new PlanForm("Madrid", "ChIJgTwKgJcpQg0RaSKMYcHeNsQ",
                                new DateTime(2018,8,1),new TimeSpan(8,0,0),
                                new DateTime(2018, 8, 8), new TimeSpan(18, 0, 0),
                                true,false
                                );
        }
    }
}

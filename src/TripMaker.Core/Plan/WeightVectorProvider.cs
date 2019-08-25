using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class WeightVectorProvider : IWeightVectorProvider
    {
        public WeightVector Generate(PlanForm planForm)
        {
            decimal TotalWeightSum = 1.0m;
            var weightVector = new WeightVector();
            weightVector.Values[0] = 0.3m;
            weightVector.Values[1] = 0.2m;
            weightVector.Values[2] = 0.1m;
            weightVector.Values[3] = 0.1m;
            weightVector.Values[4] = 0.1m;
            weightVector.Values[5] = 0.1m;
            weightVector.Values[6] = 0.1m;
            return weightVector;
        }
    }
}

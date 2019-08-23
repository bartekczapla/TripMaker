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

            return weightVector;
        }
    }
}

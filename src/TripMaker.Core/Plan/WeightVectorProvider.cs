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
            var weightVector = new WeightVector();

            return weightVector;
        }
    }
}

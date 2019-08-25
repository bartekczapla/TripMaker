using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class SawMethod : PlanAssumptions, ISawMethod
    {

        public decimal CalculateNormalizedScore(SawNormalizationMethod method, WeightVector weightVector, decimal[] rowValues, decimal[] minVector, decimal[] maxVector)
        {
            var score = 0.0m;

            for(int i=0;i< NumberOfColumns; i++)
            {
                if(method == SawNormalizationMethod.LinearFirstType)
                {
                    var isProfit = DecisionCriterias.First(x => x.Position == i).IsProfit;
                    var weight = weightVector.GetValue(i);
                    if(isProfit)
                    {
                        var denom = (maxVector[i] - minVector[i]);
                        score += denom != 0 ? (((rowValues[i] - minVector[i]) / denom) * weight) : 0;
                    } else
                    {
                        var denom = (maxVector[i] - minVector[i]);
                        score += denom != 0 ? ((1-((rowValues[i] - minVector[i])) / denom) * weight) : 0;
                    }
                } else
                {
                    return 0.0m;
                }
            }
            return score;
        }
    }
}

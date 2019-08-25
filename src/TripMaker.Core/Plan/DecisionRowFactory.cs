using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class DecisionRowFactory : PlanConsts, IDecisionRowFactory
    {
        //0. Price //1. Rating //2. Distance //3. Popularity //4.Entertainment //5. Relax //6. Activity //7. Culture //8. Sightseeing //9. Partying //10. Shopping

        public DecisionRow Create(PlanElementCandidate candidate, int iter, Location startLocation)
        {
            var row = new DecisionRow();
            row.Candidate = candidate;
            row.InitialPosition = iter;

            //0. Price
            row.SetValue(WeightVectorLabel.Price, Validate(WeightVectorLabel.Price, candidate.Price));
            //1. Rating
            row.SetValue(WeightVectorLabel.Rating, Validate(WeightVectorLabel.Rating, candidate.Rating));
            //2. Distance
            row.SetValue(WeightVectorLabel.Distance, Validate(WeightVectorLabel.Distance, (decimal)PlanHelpers.CalculateDistance(startLocation.lat, startLocation.lng, candidate.Location.lat, candidate.Location.lng)));
            //3. Popularity
            row.SetValue(WeightVectorLabel.Popularity, Validate(WeightVectorLabel.Popularity, candidate.Popularity));
            //4. Entertainment
            row.SetValue(WeightVectorLabel.Entertainment, Validate(WeightVectorLabel.Entertainment, candidate.ElementTypes.Contains(PlanElementType.Entertainment)? 1 : 0));
            //5. Relax
            row.SetValue(WeightVectorLabel.Relax, Validate(WeightVectorLabel.Relax, candidate.ElementTypes.Contains(PlanElementType.Relax) ? 1 : 0));
            //6. Activity
            row.SetValue(WeightVectorLabel.Activity, Validate(WeightVectorLabel.Activity, candidate.ElementTypes.Contains(PlanElementType.Activity) ? 1 : 0));
            //7. Culture
            row.SetValue(WeightVectorLabel.Culture, Validate(WeightVectorLabel.Culture, candidate.ElementTypes.Contains(PlanElementType.Culture) ? 1 : 0));
            //8. Sightseeing
            row.SetValue(WeightVectorLabel.Sightseeing, Validate(WeightVectorLabel.Sightseeing, candidate.ElementTypes.Contains(PlanElementType.Sightseeing) ? 1 : 0));
            //9. Partying
            row.SetValue(WeightVectorLabel.Partying, Validate(WeightVectorLabel.Partying, candidate.ElementTypes.Contains(PlanElementType.Partying) ? 1 : 0));
            //10. Shopping
            row.SetValue(WeightVectorLabel.Shopping, Validate(WeightVectorLabel.Shopping, candidate.ElementTypes.Contains(PlanElementType.Shopping) ? 1 : 0));

            return row;
        }

        private decimal Validate(WeightVectorLabel label, decimal? value)
        {
            var criteria = DecisionCriterias.First(x => x.Position == (int)label);

            if (!value.HasValue)
                return criteria.ReserveLevel;

            if(criteria.IsProfit)
            {
                return GetInRange(value.Value, criteria.ReserveLevel, criteria.AspirationLevel);
            } else
            {
                return GetInRange(value.Value, criteria.AspirationLevel, criteria.ReserveLevel);
            }
        }

        private decimal GetInRange(decimal value, decimal min, decimal max)
        {
            if (value < min) return min;
            else if (value > max) return max;
            else return value;
        }
    }
}

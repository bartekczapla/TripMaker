using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    public class DecisionRow
    {
        private int NumberOfColumns => Enum.GetNames(typeof(WeightVectorLabel)).Length;
        public PlanElementCandidate Candidate { get; set; }

        public decimal[] DecisionValues;
   
        public int InitialPosition { get; set; }
        public int ScorePosition { get; set; }
        public decimal NormalizedScore { get; set; } //znormalizowana ocena pakietów negocjacyjnych

        public DecisionRow()
        {
            DecisionValues = new decimal[NumberOfColumns];
        }

        public void SetValue(WeightVectorLabel label, decimal value)
        {
            DecisionValues[(int)label] = ValidateValue(label, value);
        }

        private decimal ValidateValue(WeightVectorLabel label, decimal value)
        {
            switch (label)
            {
                case WeightVectorLabel.Price:
                    return GetInRange(0, 4, value);
                case WeightVectorLabel.Rating:
                    return GetInRange(1.0m, 5.0m, value);
                default:
                    return GetInRange(null, null, value);
            }
        }

        private decimal GetInRange(decimal? from, decimal? to, decimal value)
        {
            if (from.HasValue && value < from)
                return from.Value;
            else if (to.HasValue && value > to)
                return to.Value;
            else
                return value;
        }

    }
}

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
        public int OptimizedPosition { get; set; }

        public decimal NormalizedScore { get; set; } //znormalizowana ocena pakietów negocjacyjnych

        public DecisionRow()
        {
            DecisionValues = new decimal[NumberOfColumns];
            OptimizedPosition = 999999;
        }

        public void SetValue(WeightVectorLabel label, decimal value)
        {
            DecisionValues[(int)label] = value;
        }



    }
}

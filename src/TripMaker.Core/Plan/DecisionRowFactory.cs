using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class DecisionRowFactory : IDecisionRowFactory
    {
        public DecisionRow Create(PlanElementCandidate candidate, int iter)
        {
            var row = new DecisionRow();
            row.Candidate = candidate;
            row.InitialPosition = iter;



            return row;
        }
    }
}

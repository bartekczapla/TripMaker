using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanElementByUserPreferencesPicker : IPlanElementByUserPreferencesPicker
    {
        public PlanElementCandidate Pick(IList<PlanElementCandidate> candidates, PlanElementType planElementType)
        {
            return null;
            //if (candidates.Any(x => x.ElementType == planElementType))
            //    return candidates.First(x => x.ElementType == planElementType);
            //else
            //    return candidates.First(x => x.ElementType == PlanElementType.Nothing); //default start from accomodation
        }
    }
}

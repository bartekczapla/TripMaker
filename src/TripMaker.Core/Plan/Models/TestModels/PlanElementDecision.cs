using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    public class PlanElementDecision
    {
        public PlanElementType ElementType { get; set; }

        public PlanElementDecision(PlanElementType elementType)
        {
            ElementType = elementType;
        }
    }
}

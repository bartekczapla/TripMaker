using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementDecisionMaker : IDomainService
    {
        PlanElementDecision Decide(DateTime currentDateTime, IList<PlanElement> currentDayElements);
    }
}

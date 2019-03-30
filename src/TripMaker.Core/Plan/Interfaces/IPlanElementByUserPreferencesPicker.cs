using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementByUserPreferencesPicker : IDomainService
    {
        PlanElementCandidate Pick(IList<PlanElementCandidate> candidates, PlanElementType planElementType);
    }
}

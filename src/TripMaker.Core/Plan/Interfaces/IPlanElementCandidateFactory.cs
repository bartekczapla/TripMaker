using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementCandidateFactory : IDomainService
    {
        Task<bool> UpdateListAsync(IList<PlanElementCandidate> candidates, IList<PlanElementCandidate> usedCandidates, PlanElementDecision decision, PlanForm planForm, Location previousLocation);
    }
}

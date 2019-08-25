using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IDecisionRowFactory : IDomainService
    {
        DecisionRow Create(PlanElementCandidate candidate, int iter, Location startLocation);
    }
}

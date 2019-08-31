using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementEatingProvider : IDomainService
    {
        Task<PlanElementCandidate> GenerateAsync(DecisionArray decisionArray, Plan plan, int whichMeal, PlanElementIteratorParams iterParams);
    }
}

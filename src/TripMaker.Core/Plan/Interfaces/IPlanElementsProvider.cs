using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementsProvider : IDomainService
    {
        // Task<Plan> GenerateAsync(PlanForm planForm);
        Task<Plan> GenerateAsync(DecisionArray decisionArray, PlanForm planForm);
    }
}

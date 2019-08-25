using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementsProvider : IDomainService
    {
        // Task<Plan> GenerateAsync(PlanForm planForm);
        Task<IList<PlanElement>> GenerateAsync(DecisionArray decisionArray, Plan plan);
    }
}

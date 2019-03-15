using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TripMaker.Plan.Interfaces
{
    public interface IPlanElementsProvider : IDomainService
    {
        Task<Plan> GenerateAsync(PlanForm planForm);

    }
}

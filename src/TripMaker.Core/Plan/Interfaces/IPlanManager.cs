using Abp.Domain.Services;
using System.Threading.Tasks;

namespace TripMaker.Plan
{
    public interface IPlanManager : IDomainService
    {
        Task<Plan> CreateAsync(PlanForm planForm);
    }
}

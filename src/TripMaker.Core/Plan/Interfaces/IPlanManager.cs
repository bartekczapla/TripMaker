using Abp.Domain.Services;
using System.Threading.Tasks;

namespace TripMaker.Plan
{
    public interface IPlanManager : IDomainService
    {
        Task CreateAsync(PlanForm planForm);
    }
}

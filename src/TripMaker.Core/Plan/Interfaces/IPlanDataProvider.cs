using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TripMaker.Plan.Interfaces
{
    public interface IPlanDataProvider : IDomainService
    {
        Task<IEnumerable<PlanElement>> ProvideDataAsync(PlanForm planForm);

        Task<bool> IsPlaceIdValid(string placeId);
    }
}

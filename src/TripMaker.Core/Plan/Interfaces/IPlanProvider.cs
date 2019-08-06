using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanProvider : IDomainService
    {
        Task<Plan> GenerateAsync(PlanForm planForm);
    }
}

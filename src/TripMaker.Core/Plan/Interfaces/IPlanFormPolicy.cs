using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripMaker.Plan.Interfaces
{
    public interface IPlanFormPolicy : IDomainService
    {
        Task CheckFormValidAsync(PlanForm planForm);
    }
}

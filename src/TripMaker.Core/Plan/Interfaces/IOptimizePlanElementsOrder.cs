using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface IOptimizePlanElementsOrder : IDomainService
    {
        Task<IList<int>> Optimize(DecisionArray decisionArray, Plan plan, int? elementsCount = null);
    }
}

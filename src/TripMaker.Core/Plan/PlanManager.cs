using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripMaker.Plan
{
    public class PlanManager : IPlanManager
    {

        private readonly IRepository<Plan> _planRepository;

        public PlanManager(IRepository<Plan> planRepository)
        {
            _planRepository=planRepository;
        }

        public async Task CreateAsync(Plan plan)
        {
            await _planRepository.InsertAsync(plan);
        }
    }
}

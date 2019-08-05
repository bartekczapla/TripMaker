using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Authorization.Users;
using TripMaker.Plan;
using TripMaker.UserPlans.Interfaces;

namespace TripMaker.UserPlans
{
    public class UserPlansManager : IUserPlansManager
    {
        private readonly IRepository<Plan.Plan> _planRepository;

        public UserPlansManager(IRepository<Plan.Plan> planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> DeleteAsync(int planId)
        {
            var plan = await _planRepository
                .GetAll()
                .Where(e => e.Id == planId)
                .FirstOrDefaultAsync();

            plan.User = null;
            plan.UserId = null;

            return true;
        }

        public async Task<List<Plan.Plan>> GetAllUserPlansAsync(long userId)
        {
            var plans = await _planRepository
                        .GetAll()
                        .Include(e => e.PlanForm)
                        .Where(e => e.UserId == userId)
                        .OrderByDescending(e => e.PlanForm.CreationTime)
                        .ToListAsync();

            return plans;
        }

        public async Task<Plan.Plan> GetDetailsAsync(int planId)
        {
            var plan = await _planRepository
                .GetAll()
                .Include(e => e.PlanForm)
                .Include(e => e.Elements)
                .ThenInclude(r => r.EndingRoute)
                .ThenInclude(r => r.Steps)
                .Where(e => e.Id == planId)
                .FirstOrDefaultAsync();

            plan.Elements.OrderBy(e => e.OrderNo);

            if (plan == null)
            {
                throw new UserFriendlyException($"Could not found the plan with id: {planId}");
            }

            return plan;
        }
    }
}


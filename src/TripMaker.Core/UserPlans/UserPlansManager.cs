using Abp.Domain.Repositories;
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

        public async Task<List<Plan.Plan>> GetAllUserPlansAsync(User user)
        {
            var plans = await _planRepository
                        .GetAll()
                        .Include(e => e.PlanForm)
                        .Where(e => e.UserId == user.Id)
                        .OrderByDescending(e => e.PlanForm.CreationTime)
                        .ToListAsync();

            return plans;
        }
    }
}


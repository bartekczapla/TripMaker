using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Authorization.Users;
using TripMaker.PlacePhotos;
using TripMaker.Plan;
using TripMaker.UserPlans.Interfaces;

namespace TripMaker.UserPlans
{
    public class UserPlansManager : IUserPlansManager
    {
        private readonly IRepository<Plan.Plan> _planRepository;
        private readonly IPlacePhotoManager _placePhotoManager;

        public UserPlansManager(IRepository<Plan.Plan> planRepository, IPlacePhotoManager placePhotoManager)
        {
            _planRepository = planRepository;
            _placePhotoManager = placePhotoManager;
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
                        .Include(e=>e.PlanAccomodation)
                        .Where(e => e.UserId == userId)
                        .OrderByDescending(e => e.PlanForm.CreationTime)
                        .ToListAsync();
            //photos
            foreach(var plan in plans)
            {
                var planForm = plan.PlanForm;
                plan.Photo = await _placePhotoManager.GetPhotos(planForm?.PlaceId);
            }

            return plans;
        }

        public async Task<Plan.Plan> GetDetailsAsync(int planId)
        {
            var plan = await _planRepository
                        .GetAll()
                      .Include(e => e.PlanFormWeightVector)
                      .Include(e => e.PlanAccomodation)
                      .Include(e => e.PlanForm)
                      .Include(e => e.Elements)
                      .ThenInclude(r => r.EndingRoute)
                      .ThenInclude(r => r.Steps)
                      .Where(e => e.Id == planId)
                      .FirstOrDefaultAsync();

            if (plan == null)
            {
                throw new UserFriendlyException($"Could not found the plan with id: {planId}");
            }

            plan.Elements.OrderBy(e => e.OrderNo);

            plan.Photo = await _placePhotoManager.GetPhotos(plan.PlanForm.PlaceId);

            return plan;
        }
    }
}


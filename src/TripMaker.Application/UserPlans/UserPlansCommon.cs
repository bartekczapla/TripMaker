using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.UserPlans.Dto;

namespace TripMaker.UserPlans
{
    public static class UserPlansCommon
    {
        public static List<UserPlansListDto> MapResult(IList<Plan.Plan> plans)
        {
            if(plans == null)
                throw new UserFriendlyException($"Could not create {typeof(List<UserPlansListDto>)} from empty {typeof(List<Plan.Plan>)}.");

            var dtos = new List<UserPlansListDto>(plans.Count);

            foreach(var plan in plans)
            {
                var planDto = new UserPlansListDto
                {
                    Id = plan.Id,
                    PlaceName = plan.PlanForm.PlaceName,
                    PlaceId = plan.PlanForm.PlaceId,
                    Destination = plan.Name,
                    Photo = plan.Photo,
                    PlanFormId = plan.PlanFormId,
                    StartDate = plan.PlanForm.StartDate,
                    StartTime = plan.PlanForm.StartTime,
                    EndDate = plan.PlanForm.EndDate,
                    EndTime = plan.PlanForm.EndTime,
                    HasJourneyBooked = plan.PlanForm.HasAccomodationBooked,
                    HasAccomodationBooked = plan.PlanForm.HasAccomodationBooked,
                    Language = plan.PlanForm.Language,
                    CreationTime = plan.PlanForm.CreationTime
                };

                dtos.Add(planDto);
            }

            return dtos;
        }

    }
}   


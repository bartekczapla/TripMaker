using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleInputFactory : IApplicationService
    {
        GooglePlaceSearchInput Create(PlanForm planForm);
    }
}

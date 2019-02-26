using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceSearchInputFactory : IDomainService
    {
        GooglePlaceSearchInput Create(PlanForm planForm);
    }
}

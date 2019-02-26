using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceNearbySearchInputFactory : IDomainService
    {
        GooglePlaceNearbySearchInput Create(PlanForm planForm);
    }
}

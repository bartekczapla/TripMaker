using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceDetailsInputFactory : IDomainService
    {
        GooglePlaceDetailsInput Create(PlanForm planForm);
    }
}

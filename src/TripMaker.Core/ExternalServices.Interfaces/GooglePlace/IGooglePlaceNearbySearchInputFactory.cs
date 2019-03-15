using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGooglePlaceNearbySearchInputFactory : IDomainService
    {
        GooglePlaceNearbySearchInput Create(Location location, LanguageType language, GooglePlaceType type);
    }
}

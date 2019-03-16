using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGooglePlaceSearchInputFactory : IDomainService
    {
        GooglePlaceSearchInput CreateUseful(Location location, GooglePlaceTypeCategory typeCategory, LanguageType language);
    }
}

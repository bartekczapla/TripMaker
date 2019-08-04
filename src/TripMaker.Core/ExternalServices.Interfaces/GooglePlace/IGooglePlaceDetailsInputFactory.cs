using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGooglePlaceDetailsInputFactory : IDomainService
    {
        GooglePlaceDetailsInput CreateAllUseful(string placeId, LanguageType language);

        GooglePlaceDetailsInput CreateAll(string placeId, LanguageType language);

        GooglePlaceDetailsInput CreateBasic(string placeId, LanguageType language);

        GooglePlaceDetailsInput CreatePhotoReference(string placeId);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Core
{
    public class GooglePlaceDetailsInputFactory : IGooglePlaceDetailsInputFactory
    {

        public GooglePlaceDetailsInput CreateAll(string placeId, LanguageType language)
        {
            var allFields = GoogleFields.Table
                                        .Where(x => x.AllowedServices.Contains(ExternalServicesType.GooglePlaceDetails)).ToList();

            return new GooglePlaceDetailsInput(placeId, language, allFields);
        }

        public GooglePlaceDetailsInput CreateAllUseful (string placeId, LanguageType language)
        {
            var allUsefulFields = GoogleFields.Table
                                        .Where(x => x.AllowedServices.Contains(ExternalServicesType.GooglePlaceDetails) &&
                                        (x.Type == GoogleFieldType.Details || x.Type == GoogleFieldType.PlaceInfo || x.Type == GoogleFieldType.Reviews))
                                        .ToList();

            return new GooglePlaceDetailsInput(placeId, language, allUsefulFields);
        }

    }
}

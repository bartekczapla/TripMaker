﻿using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceDetailsApiClient : IApplicationService
    {
        Task<GooglePlaceDetailsRootObject> GetAllAsync(string placeId);

        Task<GooglePlaceDetailsRootObject> GetAllBasicAsync(string placeId);

        Task<GooglePlaceDetailsRootObject> GetAllUsefulAsync(string placeId);
    }
}

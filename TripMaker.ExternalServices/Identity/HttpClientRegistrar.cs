﻿
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices;
using TripMaker.ExternalServices.GoogleDirections;
using TripMaker.ExternalServices.GoogleDistanceMatrix;
using TripMaker.ExternalServices.GooglePlace;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.Identity
{
    public static class HttpClientRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddHttpClient<IGooglePlaceDetailsApiClient, GooglePlaceDetailsApiClient>();
            services.AddHttpClient<IGooglePlaceSearchApiClient, GooglePlaceSearchApiClient>();
            services.AddHttpClient<IGooglePlaceNearbySearchApiClient, GooglePlaceNearbySearchApiClient>();
            services.AddHttpClient<IGooglePlacePhotosApiCaller, GooglePlacePhotosApiCaller>();
            services.AddHttpClient<IGoogleDirectionsApiClient, GoogleDirectionsApiClient>();
            services.AddHttpClient<IGoogleDistanceMatrixApiClient, GoogleDistanceMatrixApiClient>();
        }
    }
}

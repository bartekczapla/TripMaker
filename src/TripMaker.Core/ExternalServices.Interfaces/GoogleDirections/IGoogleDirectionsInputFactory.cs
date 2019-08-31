using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleDirectionsInputFactory : IDomainService
    {
        GoogleDirectionsInput Create(string originId, string destinationId, GoogleTravelMode mode, DateTime departureTime);

        GoogleDirectionsInput Create(Location origin, Location destination, GoogleTravelMode mode, DateTime departureTime);

        GoogleDirectionsInput CreateOptimizedWaypoints(Location originLoc, Location destinationLoc, GoogleTravelMode mode, IList<Location> waypoints, double? departure_time = null);
    }
}

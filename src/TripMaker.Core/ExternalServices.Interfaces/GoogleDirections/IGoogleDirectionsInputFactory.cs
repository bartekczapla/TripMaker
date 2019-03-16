using Abp.Domain.Services;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleDirectionsInputFactory : IDomainService
    {
        GoogleDirectionsInput Create(string originId, string destinationId, LanguageType language, GoogleTravelMode mode);

        GoogleDirectionsInput Create(Location origin, Location destination, LanguageType language, GoogleTravelMode mode);
    }
}

using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleUriProvider : IDomainService
    {
        string Create(GoogleDirectionsInput input);

        string Create(GoogleDistanceMatrixInput input);

        string Create(GooglePlaceDetailsInput input);

        string Create(GooglePlaceSearchInput input);

        string Create(GooglePlaceNearbySearchInput input);

        string Create(string pagetoken);

        string Create(string photoreference, int? maxheight, int? maxwidth);
    }
}

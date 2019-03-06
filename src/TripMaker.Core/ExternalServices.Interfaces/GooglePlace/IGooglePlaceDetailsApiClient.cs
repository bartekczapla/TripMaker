using Abp.Application.Services;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;

namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlaceDetailsApiClient : IDomainService
    {
        Task<GooglePlaceDetailsRootObject> GetAsync(GooglePlaceDetailsInput input);
    }
}

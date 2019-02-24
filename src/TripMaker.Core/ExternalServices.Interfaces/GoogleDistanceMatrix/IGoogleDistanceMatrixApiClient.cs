using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;

namespace TripMaker.ExternalServices.Interfaces.GoogleDistanceMatrix
{
    public interface IGoogleDistanceMatrixApiClient : IApplicationService
    {
        Task<GoogleDistanceMatrixRootObject> GetAllAsync(IList<Location> origins, IList<Location> destinations);

        Task<GoogleDistanceMatrixRootObject> GetAllAsync(IList<string> originIds, IList<string> destinationIds);
    }
}

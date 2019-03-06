using Abp.Application.Services;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;

namespace TripMaker.ExternalServices.Interfaces.GoogleDistanceMatrix
{
    public interface IGoogleDistanceMatrixApiClient : IDomainService
    {
        Task<GoogleDistanceMatrixRootObject> GetAsync(GoogleDistanceMatrixInput input);

    }
}

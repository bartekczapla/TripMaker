using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IGoogleDistanceMatrixInputFactory : IDomainService
    {
        GoogleDistanceMatrixInput Create(PlanForm planForm);
    }
}

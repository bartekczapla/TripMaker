using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.Models;

namespace TripMaker.ExternalServices.Interfaces
{
    public interface IExternalServicesJsonManager : IDomainService
    {
        Task InsertAsync(ExternalServicesJSON entity);
    }
}

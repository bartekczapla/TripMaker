using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration.Models;

namespace TripMaker.Configuration
{
    public interface ITripMakerConfigurationManager : IDomainService
    {
        Task<TripMakerConfiguration> GetConfigurationAsync(string name);

        Task<IEnumerable<TripMakerConfiguration>> GetConfigurationsAsync(IEnumerable<string> names);

        Task InsertOrUpdateConfigurationAsync(TripMakerConfiguration configuration);
    }
}

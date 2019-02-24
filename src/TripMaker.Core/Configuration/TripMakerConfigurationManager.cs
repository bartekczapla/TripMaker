using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration.Models;

namespace TripMaker.Configuration
{
    public class TripMakerConfigurationManager : ITripMakerConfigurationManager
    {
        private readonly IRepository<TripMakerConfiguration> _tripMakerConfigurationRepository;

        public TripMakerConfigurationManager(IRepository<TripMakerConfiguration> tripMakerConfigurationRepository)
        {
            _tripMakerConfigurationRepository = tripMakerConfigurationRepository;
        }

        public async Task<TripMakerConfiguration> GetConfigurationAsync(string name)
        {
            var result = await _tripMakerConfigurationRepository
                    .GetAll()
                    .Where(x => x.Name == name)
                    .FirstOrDefaultAsync();

            if (result == null) throw new UserFriendlyException($"Could not found the configuration {name}");

            return result;
        }

        public async Task<IEnumerable<TripMakerConfiguration>> GetConfigurationsAsync(IEnumerable<string> names)
        {
            var result =await _tripMakerConfigurationRepository
                    .GetAll()
                    .Where(x => names.Contains(x.Name))
                    .ToListAsync();

            if (result == null) throw new UserFriendlyException($"Could not found the configurations");

            return result;
        }

        public async Task InsertOrUpdateConfigurationAsync(TripMakerConfiguration configuration)
        {
            var conf = await _tripMakerConfigurationRepository
                .GetAll()
                .Where(x => x.Name == configuration.Name)
                .FirstOrDefaultAsync();

            if(conf == null)
            {
                await _tripMakerConfigurationRepository.InsertAsync(configuration);
            }
            else
            {
                conf.Value = configuration.Value;
            }
        }
    }
}

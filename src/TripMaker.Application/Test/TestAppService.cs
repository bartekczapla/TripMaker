using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using TripMaker.Configuration;
using TripMaker.ExternalServices;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.GooglePlace;
using TripMaker.ExternalServices.Interfaces;

namespace TripMaker.Test
{
    public class TestAppService : ITestAppService
    {
        private readonly ITripMakerConfigurationManager _configurationManager;

        public TestAppService(ITripMakerConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public async Task GetTestAsync()
        {
            //await _configurationManager.InsertOrUpdateConfigurationAsync(new Configuration.Models.TripMakerConfiguration("Name", "ValueType", "Value"));

            Console.Write("Test");
        }
    }
}

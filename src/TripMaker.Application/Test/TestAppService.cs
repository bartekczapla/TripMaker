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
using TripMaker.Plan;

namespace TripMaker.Test
{
    public class TestAppService : ITestAppService
    {
        private readonly ITripMakerConfigurationManager _configurationManager;
        private readonly IPlanManager _planManager;

        public TestAppService(ITripMakerConfigurationManager configurationManager, IPlanManager planManager)
        {
            _configurationManager = configurationManager;
            _planManager = planManager;

        }

        public async Task GetTestAsync()
        {
            var input = new PlanForm("Madrid", "ChIJgTwKgJcpQg0RaSKMYcHeNsQ",
                                    new DateTime(2019, 8, 1), new TimeSpan(8, 0, 0),
                                    new DateTime(2019, 8, 8), new TimeSpan(18, 0, 0),
                                    Enums.LanguageType.Pl);

            await _planManager.CreateAsync(input);

            Console.Write("Test");
        }
    }
}

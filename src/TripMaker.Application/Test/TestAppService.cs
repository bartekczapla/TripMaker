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
        private readonly IGoogleDirectionsApiClient _googleDirectionsApiClient;

        public TestAppService(IGoogleDirectionsApiClient googleDirectionsApiClient)
        {
            _googleDirectionsApiClient = googleDirectionsApiClient;
        }

        public async Task GetTestAsync()
        {
            var test=await _googleDirectionsApiClient.GetAllAsync("ChIJFaTSgngUPEcR1hOE8XeFQMY", "ChIJ89z6UDR1FkcRwugSFONLbJc");

            Console.Write("Test");
        }
    }
}

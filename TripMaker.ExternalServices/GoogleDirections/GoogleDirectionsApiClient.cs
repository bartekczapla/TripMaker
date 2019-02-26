using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration;
using Newtonsoft.Json;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Entities.GoogleDirections;

namespace TripMaker.ExternalServices.GoogleDirections
{
    public class GoogleDirectionsApiClient : IGoogleDirectionsApiClient
    {
        public HttpClient _httpClient;
        private readonly IGoogleUriProvider _googleUriProvider;

        public GoogleDirectionsApiClient(HttpClient httpClient, IGoogleUriProvider googleUriProvider)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/directions/");
            _httpClient = httpClient;
            _googleUriProvider = googleUriProvider;

        }

        public async Task<GoogleDirectionsRootObject> GetAsync(GoogleDirectionsInput input)
        {
            var uri = _googleUriProvider.Create(input);
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result= JsonConvert.DeserializeObject<GoogleDirectionsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

    }
}

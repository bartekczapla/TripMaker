using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlaceSearchApiClient : IGooglePlaceSearchApiClient
    {
        public HttpClient _httpClient;
        private readonly IGoogleUriProvider _googleUriProvider;

        public GooglePlaceSearchApiClient(HttpClient httpClient, IGoogleUriProvider googleUriProvider)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/findplacefromtext/");
            _httpClient = httpClient;
            _googleUriProvider = googleUriProvider;
        }

        public async Task<GooglePlaceSearchRootObject> GetAsync(GooglePlaceSearchInput input)
        {
            var uri = _googleUriProvider.Create(input);
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceSearchRootObject>(resultJson);
            result.resultJson = resultJson;
            result.inputUri = uri;
            return result;
        }
    }
}

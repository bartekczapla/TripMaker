using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlaceNearbySearchApiClient : BaseGooglePlaceApiClient, IGooglePlaceNearbySearchApiClient
    {
        public HttpClient _httpClient;
        private readonly IGoogleUriProvider _googleUriProvider;

        public GooglePlaceNearbySearchApiClient(HttpClient httpClient, IGoogleUriProvider googleUriProvider)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/");
            _httpClient = httpClient;
            _googleUriProvider = googleUriProvider;
        }

        public async Task<GooglePlaceNearbySearchRootObject> GetAsync(GooglePlaceDetailsInput input)
        {
            var uri = _googleUriProvider.Create(input);
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceNearbySearchRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceNearbySearchRootObject> GetNextPageTokenAsync(string token)
        {
            var uri = _googleUriProvider.Create(token);
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceNearbySearchRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }
    }
}

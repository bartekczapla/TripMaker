using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration;
using Newtonsoft.Json;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.ExternalServices.Interfaces;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlaceDetailsApiClient : BaseGooglePlaceApiClient, IGooglePlaceDetailsApiClient
    {
        public HttpClient _httpClient;
        private readonly IGoogleUriProvider _googleUriProvider;

        public GooglePlaceDetailsApiClient(HttpClient httpClient, IGoogleUriProvider googleUriProvider)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/details/");
            _httpClient = httpClient;
            _googleUriProvider = googleUriProvider;
        }


        public async Task<GooglePlaceDetailsRootObject> GetAsync(GooglePlaceDetailsInput input)
        {
            var uri = _googleUriProvider.Create(input);
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceDetailsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }
    }
}

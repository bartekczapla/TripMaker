using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration;
using Newtonsoft.Json;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Interfaces.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Interfaces;

namespace TripMaker.ExternalServices.GoogleDistanceMatrix
{
    public class GoogleDistanceMatrixApiClient : IGoogleDistanceMatrixApiClient
    {
        public HttpClient _httpClient;
        private readonly IGoogleUriProvider _googleUriProvider;

        public GoogleDistanceMatrixApiClient(HttpClient httpClient, IGoogleUriProvider googleUriProvider)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/distancematrix/");
            _httpClient = httpClient;
            _googleUriProvider = googleUriProvider;
        }


        public async Task<GoogleDistanceMatrixRootObject> GetAsync(GoogleDistanceMatrixInput input)
        {
            var uri = _googleUriProvider.Create(input);
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GoogleDistanceMatrixRootObject>(resultJson);
            result.resultJson = resultJson;
            result.inputUri = uri;

            return result;
        }

    }
}

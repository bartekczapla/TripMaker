using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration;
using Newtonsoft.Json;
using static TripMaker.ExternalServices.Helpers.GooglePlaceCommon;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Entities.GoogleDirections;

namespace TripMaker.ExternalServices.GoogleDirections
{
    public class GoogleDirectionsApiClient : IGoogleDirectionsApiClient
    {
        public HttpClient _httpClient;
        private static string GoogleApiKey;

        public GoogleDirectionsApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/directions/");
            _httpClient = httpClient;
            GoogleApiKey = Config.GoogleApiKey;
        }


        //Required parameters: 
        //-key
        //-origin — The address, textual latitude/longitude value, or place ID from which you wish to calculate directions.
        // - destination — The address, textual latitude/longitude value, or place ID 

        //Optional parameters:
        //- language = {en, pl}
        //


        public async Task<GoogleDirectionsRootObject> GetAllAsync(Location origin, Location destination)
        {
            var uri = $"json?&origin={origin.lat},{origin.lng}&destination={destination.lat},{destination.lng}&key={GoogleApiKey}";
            var result = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<GoogleDirectionsRootObject>(result);
        }

        public async Task<GoogleDirectionsRootObject> GetAllAsync(string originPlaceId, string destinationPlaceId)
        {
            var uri = $"json?&origin=place_id:{originPlaceId}&destination=place_id:{destinationPlaceId}&key={GoogleApiKey}";
            var result = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<GoogleDirectionsRootObject>(result);
        }
    }
}

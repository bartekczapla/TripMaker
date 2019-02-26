using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration;
using Newtonsoft.Json;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using static TripMaker.ExternalServices.Helpers.GooglePlaceCommon;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlaceDetailsApiClient : BaseGooglePlaceApiClient, IGooglePlaceDetailsApiClient
    {
        public HttpClient _httpClient;
        private static string GoogleApiKey;

        public GooglePlaceDetailsApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/details/");
            _httpClient = httpClient;
            GoogleApiKey = Config.GoogleApiKey;
        }


        //Required parameters: 
        //-key
        //-placeid  

        //Optional parameters:
        //- language = {en, pl}
        //- fields


        public async Task<GooglePlaceDetailsRootObject> GetAllAsync(string placeId)
        {
            var uri = $"json?placeid={placeId}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceDetailsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceDetailsRootObject> GetAllBasicAsync(string placeId)
        {
            var uri = $"json?placeid={placeId}&fields=address_component,adr_address,alt_id,formatted_address,geometry,icon,id,name,permanently_closed,photo,place_id,plus_code,scope,type,url,utc_offset,vicinity&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceDetailsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceDetailsRootObject> GetAllUsefulAsync(string placeId)
        {
            var uri = $"json?placeid={placeId}&fields=geometry/location,id,opening_hours,name,place_id,price_level,rating,reviews,scope,types&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceDetailsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceDetailsRootObject> GetMinimumAsync(string placeId)
        {
            var uri = $"json?placeid={placeId}&fields=geometry/location&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceDetailsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }
    }
}

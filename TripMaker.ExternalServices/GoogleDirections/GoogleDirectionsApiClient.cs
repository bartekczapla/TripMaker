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
        //- mode {driving, walking, bicycling, transit(+departure_time, arrival_tie)}
        //- waypoints (intermediate locations) =via:lat%2Clng| =via:place_id:{id}|place_id:{id2}
        //- optimize waypoints( travelling salesperson problem) np &waypoints=optimize:true|Barossa+Valley,SA|Clare,SA
        // and return "waypoint_order": [ 3, 2, 0, 1 ]
        // -alternatives {true,false} alternative routes
        // - avoid {tolls|highways|ferries|indoor}
        // - unit={metirc}
        // - arrival_time/departure_time - Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC
        //mode is driving: You can specify the departure_time to receive a route and trip duration   that take traffic conditions into account. 
        // -traffic_model {best_guess ,pessimistic ,optimistic )
        // - transit_mode={bus,subway,train,tram,rail}
        // -transit_routing_preference {less_walking, fewer_transfers} 



        public async Task<GoogleDirectionsRootObject> GetAllAsync(Location origin, Location destination)
        {
            var uri = $"json?&origin={origin.lat},{origin.lng}&destination={destination.lat},{destination.lng}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result= JsonConvert.DeserializeObject<GoogleDirectionsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GoogleDirectionsRootObject> GetAllAsync(string originPlaceId, string destinationPlaceId)
        {
            var uri = $"json?&origin=place_id:{originPlaceId}&destination=place_id:{destinationPlaceId}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GoogleDirectionsRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }
    }
}

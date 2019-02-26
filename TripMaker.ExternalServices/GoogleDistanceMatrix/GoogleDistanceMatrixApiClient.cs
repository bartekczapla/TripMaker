using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripMaker.Configuration;
using Newtonsoft.Json;
using static TripMaker.ExternalServices.Helpers.GooglePlaceCommon;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Interfaces.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.ExternalServices.GoogleDistanceMatrix
{
    public class GoogleDistanceMatrixApiClient : IGoogleDistanceMatrixApiClient
    {
        public HttpClient _httpClient;
        private static string GoogleApiKey;

        public GoogleDistanceMatrixApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/distancematrix/");
            _httpClient = httpClient;
            GoogleApiKey = Config.GoogleApiKey;
        }


        //Required parameters: 
        //-key
        //-origins={lat,lng}|{lat2,lng2}  origins=place_id:{id}|place_id:{id2}
        //-destinations={lat,lng}|{lat2,lng2}  destinations=place_id:{id}|place_id:{id2}

        //Optional parameters:
        //- language = {en, pl}
        //- mode {driving, walking, bicycling, transit(+departure_time, arrival_tie)}
        // - avoid {tolls|highways|ferries|indoor}
        // - unit={metirc}
        // - arrival_time/departure_time - Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC
        //mode is driving: You can specify the departure_time to receive a route and trip duration   that take traffic conditions into account. 
        // -traffic_model {best_guess ,pessimistic ,optimistic )
        // -transit_mode={bus,subway,train,tram,rail}
        // -transit_routing_preference {less_walking, fewer_transfers} 


        //Rows are ordered according to the values in the origin parameter of the request.Each row corresponds to an origin, and each element within that row corresponds to a pairing of the origin with a destination value.
        //Each row array contains one or more element entries, which in turn contain the information about a single origin-destination pairing.

        public async Task<GoogleDistanceMatrixRootObject> GetAllAsync(IList<Location> origins, IList<Location> destinations)
        {
            var uri = $"json?&origins={ConvertLocationsToString(origins)}&destinations={ConvertLocationsToString(destinations)}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GoogleDistanceMatrixRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GoogleDistanceMatrixRootObject> GetAllAsync(IList<string> originIds, IList<string> destinationIds)
        {
            var uri = $"json?&origins={ConvertPlaceIdsToString(originIds)}&destinations={ConvertPlaceIdsToString(destinationIds)}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GoogleDistanceMatrixRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

    }
}

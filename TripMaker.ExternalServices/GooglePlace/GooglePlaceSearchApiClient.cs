using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using static TripMaker.ExternalServices.Helpers.GooglePlaceCommon;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlaceSearchApiClient : BaseGooglePlaceApiClient, IGooglePlaceSearchApiClient
    {
        public HttpClient _httpClient;
        private static string GoogleApiKey;

        public GooglePlaceSearchApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/findplacefromtext/");
            _httpClient = httpClient;
            GoogleApiKey = ConfigUtil.GetAppConfigSetting("GooglePlaceApiKey");
        }


        //Required parameters: 
        //-key
        //-inputtype = {textquery , phonenumber}
        //-input ...

        //Optional parameters:
        //- language = {en, pl}
        //- fields
        //- locationbias = {ipbiad | point:lat,lng | circle:radius@lat,lng |rectangle:south,west|north,east}



        public async Task<GooglePlaceSearchRootObject> GetAllAsync(string input)
        {
            ReplaceSpace(ref input);
            var uri = $"json?input={input}&inputtype=textquery&fields=formatted_address,geometry,icon,id,name,permanently_closed,photos,place_id,plus_code,types,opening_hours,price_level,rating&key={GoogleApiKey}";
            var result = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<GooglePlaceSearchRootObject>(result);
        }
    }
}

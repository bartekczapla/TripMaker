
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlacePhotosApiCaller : BaseGooglePlaceApiClient, IGooglePlacePhotosApiCaller
    {
        public HttpClient _httpClient;
        private static string GoogleApiKey;

        public GooglePlacePhotosApiCaller(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/");
            _httpClient = httpClient;
            GoogleApiKey = ConfigUtil.GetAppConfigSetting("GooglePlaceApiKey");
        }

        //Required parameters: 
        //-key
        //-photoreference  =
        //-maxheight or maxwidth 


        public async Task<string> GetPhotoAsync(string photoreference, int? maxheight, int? maxwidth)
        {
            string size = maxheight != null ? $"maxheight={maxheight}" : $"maxwidth={maxwidth}";
            var uri = $"photo?{size}&photoreference={photoreference}&key={GoogleApiKey}";
            var result = await _httpClient.GetStringAsync(uri);
            return "photo";
        }
    }
}

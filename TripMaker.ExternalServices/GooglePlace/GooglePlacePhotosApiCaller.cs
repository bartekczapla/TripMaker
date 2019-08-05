
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlacePhotosApiCaller : IGooglePlacePhotosApiCaller
    {
        public HttpClient _httpClient;
        private readonly IGoogleUriProvider _googleUriProvider;

        public GooglePlacePhotosApiCaller(HttpClient httpClient, IGoogleUriProvider googleUriProvider)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/");
            _httpClient = httpClient;
            _googleUriProvider = googleUriProvider;
        }

        //Required parameters: 
        //-key
        //-photoreference  =
        //-maxheight or maxwidth 

        public async Task<string> GetPhotoAsync(string photoreference, int? maxheight, int? maxwidth)
        {
            var uri = _googleUriProvider.Create(photoreference, maxheight, maxwidth);
            var content = await _httpClient.GetByteArrayAsync(uri);
            if (content != null)
                return Convert.ToBase64String(content);
            else
                return String.Empty;
        }
    }
}

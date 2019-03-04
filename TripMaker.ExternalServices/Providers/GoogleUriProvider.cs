using System;
using System.Text;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.ExternalServices.Interfaces;

namespace TripMaker.ExternalServices.Providers
{
    public class GoogleUriProvider : IGoogleUriProvider
    {
        private static string GoogleApiKey;
        private static string Output = "json";

        public GoogleUriProvider()
        {
            GoogleApiKey = Config.GoogleApiKey;
        }

        public string Create(GoogleDirectionsInput input)
        {
            StringBuilder builder = new StringBuilder();
            //   StringBuilder builder
            //    var uri = $"json?&origin={origin.lat},{origin.lng}&destination={destination.lat},{destination.lng}&key={GoogleApiKey}";
            //    var uri = $"json?&origin=place_id:{originPlaceId}&destination=place_id:{destinationPlaceId}&key={GoogleApiKey}";

            return builder.ToString();
        }

        public string Create(GoogleDistanceMatrixInput input)
        {
            StringBuilder builder = new StringBuilder();
            //var uri = $"json?&origins={ConvertLocationsToString(origins)}&destinations={ConvertLocationsToString(destinations)}&key={GoogleApiKey}";
            //var uri = $"json?&origins={ConvertPlaceIdsToString(originIds)}&destinations={ConvertPlaceIdsToString(destinationIds)}&key={GoogleApiKey}";

            return builder.ToString();
        }

        public string Create(GooglePlaceDetailsInput input)
        {
            StringBuilder builder = new StringBuilder();
            //var uri = $"json?placeid={placeId}&fields=address_component,adr_address,alt_id,formatted_address,geometry,icon,id,name,permanently_closed,photo,place_id,plus_code,scope,type,url,utc_offset,vicinity&key={GoogleApiKey}";
            //var uri = $"json?placeid={placeId}&fields=geometry/location,id,opening_hours,name,place_id,price_level,rating,reviews,scope,types&key={GoogleApiKey}";
            //var uri = $"json?placeid={placeId}&fields=geometry/location&key={GoogleApiKey}";
            return builder.ToString();
        }

        public string Create(GooglePlaceSearchInput input)
        {
            StringBuilder builder = new StringBuilder();
            //EncodeString(ref input);
            //var uri = $"json?input={input}&inputtype=textquery&fields={AllFields}&key={GoogleApiKey}";

            //var uri = $"json?input={input}&inputtype=textquery&fields={AllFields}&locationbias=point:{location.lat},{location.lng}&key={GoogleApiKey}";

            //var uri = $"json?input={input}&inputtype=textquery&fields={AllFields}&locationbias=circle:{radius}@{location.lat},{location.lng}&key={GoogleApiKey}";

            return builder.ToString();
        }

        public string Create(GooglePlaceNearbySearchInput input)
        {
            StringBuilder builder = new StringBuilder();

            //    var uri = $"json?location={location.lat},{location.lng}&radius={radius}&key={GoogleApiKey}";
            //    var uri = $"json?location={location.lat},{location.lng}&rankby=distance&keyword={keyword}&key={GoogleApiKey}";
            //    var uri = $"json?location={location.lat},{location.lng}&rankby=distance&type={type}&key={GoogleApiKey}";
            //    var uri = $"json?pagetoken={token}y&key={GoogleApiKey}";

            return builder.ToString();
        }

        public string Create(string pagetoken)
        {
            StringBuilder builder = new StringBuilder();
            //    var uri = $"json?pagetoken={token}y&key={GoogleApiKey}";

            return builder.ToString();
        }

        public string Create(string photoreference, int? maxheight, int? maxwidth)
        {
            StringBuilder builder = new StringBuilder();
            //string size = maxheight != null ? $"maxheight={maxheight}" : $"maxwidth={maxwidth}";
            //var uri = $"photo?{size}&photoreference={photoreference}&key={GoogleApiKey}";
            return builder.ToString();
        }
    }
}

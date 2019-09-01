using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.Helpers.Extensions;
using static TripMaker.ExternalServices.Helpers.GooglePlaceUriCommon;

namespace TripMaker.ExternalServices.Core
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
            builder.Append($"{Output}?key={GoogleApiKey}");
            if (!String.IsNullOrWhiteSpace(input.OriginPlaceId) && !String.IsNullOrWhiteSpace(input.DestinationPlaceId))
            {
                builder.Append($"&origin=place_id:{input.OriginPlaceId}");
                builder.Append($"&destination=place_id:{input.DestinationPlaceId}");
            }
            else
            {
                builder.Append($"&origin={input.OriginLoc.lat.ToString(System.Globalization.CultureInfo.InvariantCulture)},{input.OriginLoc.lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
                builder.Append($"&destination={input.DestinationLoc.lat.ToString(System.Globalization.CultureInfo.InvariantCulture)},{input.DestinationLoc.lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
            builder.Append($"&language={input.Language.GetString()}");
            builder.Append($"&mode={input.Mode.GetString()}");

            if (input.WaypointsLoc.Any())
            {
                builder.Append($"&waypoints=");

                if (input.OptimizeWaypoints) builder.Append($"optimize:true|");

                var waypoints = ConvertLocationsToString(input.WaypointsLoc);

                builder.Append($"{waypoints}");
            }

            if (input.Restrictions != Enums.GoogleRestrictions.none)
            {
                builder.Append($"&avoid={input.Restrictions.GetString()}");
            }

            builder.Append($"&units={input.Units}");

            if (input.Departure_time != null)
            {
                builder.Append($"&departure_time={input.Departure_time}");
            }

            if (input.Mode == Enums.GoogleTravelMode.Transit && input.TransitRouting != Enums.TransitRoutingPreference.none)
            {
                builder.Append($"&transit_routing_preference={input.TransitRouting.GetString()}");
            }

            return builder.ToString();
        }

        public string Create(GoogleDistanceMatrixInput input)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Output}?key={GoogleApiKey}");
            if (input.OriginsLoc.Any() || input.OriginsPlaceId.Any())
            {
                builder.Append($"&origins={ConvertLocationsToString(input.OriginsLoc, input.OriginsPlaceId)}");
            }
            if (input.DestinationsLoc.Any() || input.DestinationsPlaceId.Any())
            {
                builder.Append($"&destinations={ConvertLocationsToString(input.DestinationsLoc, input.DestinationsPlaceId)}");
            }
            builder.Append($"&language={input.Language.GetString()}");
            builder.Append($"&mode={input.Mode.GetString()}");

            if (input.Restrictions != Enums.GoogleRestrictions.none)
            {
                builder.Append($"&avoid={input.Restrictions.GetString()}");
            }

            builder.Append($"&units={input.Units}");

            if (input.Departure_time != null)
            {
                builder.Append($"&departure_time={input.Departure_time}");
            }

            if (input.Mode == Enums.GoogleTravelMode.Transit && input.TransitRouting != Enums.TransitRoutingPreference.none)
            {
                builder.Append($"&transit_routing_preference={input.TransitRouting.GetString()}");
            }

            return builder.ToString();
        }

        public string Create(GooglePlaceDetailsInput input)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Output}?key={GoogleApiKey}");
            builder.Append($"&placeid={input.PlaceId}");
            builder.Append($"&language={input.Language.GetString()}");

            if (input.Fields.Count > 0)
            {
                var fields = String.Join(",", input.Fields.Select(x => x.Name).ToArray());
                builder.Append($"&fields={fields}");
            }

            return builder.ToString();
        }

        public string Create(GooglePlaceSearchInput input)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Output}?key={GoogleApiKey}");
            builder.Append($"&input={EncodeString(input.Input)}");
            builder.Append($"&inputtype=textquery");
            builder.Append($"&language={input.Language.GetString()}");

            if (input.Fields.Count > 0)
            {
                var fields = String.Join(",", input.Fields.Select(x => x.Name).ToArray());
                builder.Append($"&fields={fields}");
            }

            if (input.Location != null && input.Radius == null)
            {
                builder.Append($"&locationbias=point:{input.Location.lat.ToString(System.Globalization.CultureInfo.InvariantCulture)},{input.Location.lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
            else if (input.Location != null && input.Radius != null)
            {
                builder.Append($"&locationbias=circle:{input.Radius}@{input.Location.lat.ToString(System.Globalization.CultureInfo.InvariantCulture)},{input.Location.lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }

            return builder.ToString();
        }

        public string Create(GooglePlaceNearbySearchInput input)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Output}?key={GoogleApiKey}");
            builder.Append($"&location={(input.Location.lat).ToString(System.Globalization.CultureInfo.InvariantCulture)},{input.Location.lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}");

            if (input.Radius != null)
            {
                builder.Append($"&radius={input.Radius}");
            }
            else
            {
                builder.Append($"&rankby=distance");
            }
            builder.Append($"&language={input.Language.GetString()}");

            if (!String.IsNullOrWhiteSpace(input.Keyword)) builder.Append($"&keyword={EncodeString(input.Keyword)}");


            if (input.Type != null)
            {
                if(!String.IsNullOrWhiteSpace(input.Type.Name))
                    builder.Append($"&type={input.Type.Name}");
            }
               
            if (input.Minprice != null) builder.Append($"&minprice={input.Minprice}");

            if (input.Maxprice != null) builder.Append($"&maxprice={input.Maxprice}");

            return builder.ToString();
        }

        public string Create(string pagetoken)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Output}?key={GoogleApiKey}");
            builder.Append($"&pagetoken={pagetoken}");

            return builder.ToString();
        }

        public string Create(string photoreference, int? maxheight, int? maxwidth)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"photo?key={GoogleApiKey}");
            builder.Append($"&photoreference={photoreference}");

            if (maxheight != null)
                builder.Append($"&maxheight={maxheight}");
            else
                builder.Append($"&maxwidth={maxwidth}");

            return builder.ToString();
        }
    }
}

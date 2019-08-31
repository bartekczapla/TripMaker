
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch
{
    public class GooglePlaceNearbySearchInput
    {
        public GooglePlaceNearbySearchInput()
        {

        }

        public GooglePlaceNearbySearchInput(Location location,int radius, LanguageType language )
        {
            Location = location;
            Language = language;
            Radius = (int)radius;
            Rankby = GoogleRankby.Prominence;
        }

        public GooglePlaceNearbySearchInput(Location location, int radius, GooglePlaceType type, LanguageType language)
        {
            Location = location;
            Language = language;
            Radius = (int)radius;
            Type = type;
            Rankby = GoogleRankby.Prominence;
        }

        public GooglePlaceNearbySearchInput(Location location, LanguageType language, string keyword, GooglePlaceType type, int? minprice=null, int? maxprice = null)
        {
            Location = location;
            Language = language;
            Rankby = GoogleRankby.Distance;
            Keyword = keyword;
            Type = type;
            Minprice = minprice;
            Maxprice = maxprice;
        }

        public Location Location { get; set; }
        public int? Radius { get; set; }
        public LanguageType Language { get; set; }
        public string Keyword { get; set; }
        public GoogleRankby Rankby { get; set; }
        public int? Minprice { get; set; } //0-4
        public int? Maxprice { get; set; } //0-4
        public GooglePlaceType Type { get; set; }
    }
}

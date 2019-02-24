using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceSearch
{
    public class GooglePlaceSearchInput
    {
        public GooglePlaceSearchInput()
        {
            Fields = new Collection<string>();
        }

        public GooglePlaceSearchInput(string input, Location location, string language, int? radius=null)
        {
            Input = input;
            Location = location;
            Language = language;
            Radius = radius;
            Fields = new Collection<string>();
        }

        public string Input { get; set; }
        public Location Location { get; set; }
        public int? Radius { get; set; }
        public string Language { get; set; }
        public ICollection<string> Fields { get; set; }
    }
}

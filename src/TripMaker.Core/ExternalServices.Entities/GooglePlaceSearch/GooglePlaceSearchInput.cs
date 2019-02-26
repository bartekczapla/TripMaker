using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Entities.GooglePlaceSearch
{
    public class GooglePlaceSearchInput
    {
        public GooglePlaceSearchInput()
        {
            Fields = new Collection<GoogleField>();
        }

        public GooglePlaceSearchInput(string input, Location location, LanguageType language, int? radius=null)
        {
            Input = input;
            Location = location;
            Language = language;
            Radius = radius;
            Fields = new Collection<GoogleField>();
        }

        public string Input { get; set; }
        public Location Location { get; set; }
        public int? Radius { get; set; }
        public LanguageType Language { get; set; }
        public ICollection<GoogleField> Fields { get; set; }
    }
}

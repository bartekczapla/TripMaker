using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;

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

        public GooglePlaceSearchInput(string input, Location location, LanguageType language, IList<GoogleField> fields)
        {
            Input = input;
            Location = location;
            Language = language;
            Fields = new Collection<GoogleField>(fields);
        }

        public GooglePlaceSearchInput(string input, Location location, int radius, IList<GoogleField> fields, LanguageType language)
        {
            Input = input;
            Location = location;
            Language = language;
            Radius = radius;
            Fields = new Collection<GoogleField>(fields);
        }

        public string Input { get; set; }
        public Location Location { get; set; }
        public int? Radius { get; set; }
        public LanguageType Language { get; set; }
        public ICollection<GoogleField> Fields { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Entities.GooglePlaceDetails
{
    public class GooglePlaceDetailsInput
    {
        public GooglePlaceDetailsInput()
        {
            Fields = new Collection<GoogleField>();
        }

        public GooglePlaceDetailsInput(string placeId, LanguageType language)
        {
            PlaceId = placeId;
            Language = language;
            Fields = new Collection<GoogleField>();
        }

        public string PlaceId { get; set; }
        public LanguageType Language { get; set; }
        public ICollection<GoogleField> Fields { get; set; }
    }
}

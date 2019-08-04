using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Entities
{
    public class GoogleField
    {
        public GoogleField(string name, GoogleFieldType type, IEnumerable<ExternalServicesType> allowedServices)
        {
            Name = name;
            Type = type;
            AllowedServices = new Collection<ExternalServicesType>(allowedServices.ToList());
        }
        public string Name { get; set; }
        public GoogleFieldType Type { get; set; }
        public Collection<ExternalServicesType> AllowedServices { get; set; }
    }

    public static class GoogleFields
    {
        public static ICollection<GoogleField> Table =new Collection<GoogleField>
        {
            new GoogleField("formatted_address", GoogleFieldType.Address, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("geometry", GoogleFieldType.Address, new ExternalServicesType[] { ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("icon", GoogleFieldType.Photos, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("id", GoogleFieldType.Details, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("name", GoogleFieldType.Details, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch , ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("permanently_closed", GoogleFieldType.PlaceInfo, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("photos", GoogleFieldType.Photos, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch  }),
            new GoogleField("place_id", GoogleFieldType.Details, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("plus_code", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("scope", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("types", GoogleFieldType.PlaceInfo, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch  }),
            new GoogleField("opening_hours", GoogleFieldType.Details, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch , ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("price_level", GoogleFieldType.Reviews, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails   }),
            new GoogleField("user_ratings_total", GoogleFieldType.Reviews, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails  }),
            new GoogleField("rating", GoogleFieldType.Reviews, new ExternalServicesType[] {ExternalServicesType.GooglePlaceSearch, ExternalServicesType.GooglePlaceDetails   }),

            new GoogleField("address_component", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("adr_address", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("alt_id", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("photos", GoogleFieldType.Photos, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("type", GoogleFieldType.PlaceInfo, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("url", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails}),
            new GoogleField("vicinity", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails}),
            new GoogleField("formatted_phone_number", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("utc_offset", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("website", GoogleFieldType.Others, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails }),
            new GoogleField("review", GoogleFieldType.Reviews, new ExternalServicesType[] {ExternalServicesType.GooglePlaceDetails })
        };
    }
}



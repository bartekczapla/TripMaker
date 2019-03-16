using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;

namespace TripMaker.ExternalServices.Helpers
{
    public static class InterpreteGooglePlaceTypeCategory
    {
        public static GooglePlaceTypeCategory Interprete(string type)
        {
            return GooglePlaceTypes.Table.FirstOrDefault(x => x.Name == type).Type;
        }

        public static IEnumerable<GooglePlaceTypeCategory> Interprete(IEnumerable<string> types)
        {
            var categories = new List<GooglePlaceTypeCategory>();

            foreach (var type in types)
                categories.Add(GooglePlaceTypes.Table.FirstOrDefault(x => x.Name == type).Type);

            return categories;
        }
    }
}

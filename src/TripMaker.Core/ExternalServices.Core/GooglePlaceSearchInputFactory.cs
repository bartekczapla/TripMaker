using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Core
{
    public class GooglePlaceSearchInputFactory : IGooglePlaceSearchInputFactory
    {
        private const string AllFields = "formatted_address,geometry,icon,id,name,permanently_closed,photos,place_id,plus_code,types,opening_hours,price_level,rating";


        //Required parameters: 
        //-key
        //-inputtype = {textquery , phonenumber}
        //-input ...

        //Optional parameters:
        //- language = {en, pl}
        //- fields   {formatted_address, geometry, icon, id, name, permanently_closed, photos, place_id, plus_code, scope, types,price_level, rating,opening_hours}
        //- locationbias = {ipbiad | point:lat,lng | circle:radius@lat,lng |rectangle:south,west|north,east}


        public GooglePlaceSearchInput CreateUseful(Location location, GooglePlaceTypeCategory typeCategory, LanguageType language)
        {
            var allUsefulFields = GoogleFields.Table
                            .Where(x => x.AllowedServices.Contains(ExternalServicesType.GooglePlaceSearch) &&
                            (x.Type == GoogleFieldType.Details || x.Type == GoogleFieldType.PlaceInfo || x.Type == GoogleFieldType.Reviews))
                            .ToList();

            var input = GooglePlaceTypes.Table.First(x => x.Type == typeCategory).Name;

            return new GooglePlaceSearchInput(input, location, language, allUsefulFields);
        }
    }
}

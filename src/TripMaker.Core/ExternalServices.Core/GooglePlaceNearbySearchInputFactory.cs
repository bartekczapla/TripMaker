using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Core
{
    public class GooglePlaceNearbySearchInputFactory : IGooglePlaceNearbySearchInputFactory
    {

        //Required parameters: 
        //-key
        //-location=lat,long
        //-radius={...meters} !not when rankby=distance

        //Optional parameters:
        //- language = {en, pl}
        //- keyword= {term to be matched against all content} !If rankby=distance
        //= minprice, maxprice= 0(affordable) to 4(expensive)
        //-name = {like keyword}
        //- rankby={prominence, distance}  !prominence based on importance, distance based on distance from location, 
        // if rankby=distance is specified, then one or more of keyword, name, or type is required
        //- type= {result matching specified tyep} !only one !If rankby=distance
        //- pagetoken -Returns the next 20 results from a previously run search. Setting a pagetoken parameter will execute a search with the same parameters used previously


        public GooglePlaceNearbySearchInput Create(Location location, GooglePlaceTypeCategory typeCategory)
        {
            LanguageType language = LanguageType.Pl;
            var types = GooglePlaceTypes.Table.Where(x => x.Type == typeCategory).ToList();
            Random rnd = new Random();
            var index=rnd.Next(types.Count);

            return new GooglePlaceNearbySearchInput(location, language, String.Empty, types[index]);
        }

        public GooglePlaceNearbySearchInput Create(Location location, int radius, GooglePlaceType type)
        {
            return new GooglePlaceNearbySearchInput(location, radius, type, LanguageType.Pl);
        }
    }
}

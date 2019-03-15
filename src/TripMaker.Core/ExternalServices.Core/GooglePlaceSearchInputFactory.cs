using System;
using System.Collections.Generic;
using System.Text;
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


        public GooglePlaceSearchInput Create(PlanForm planForm)
        {

            throw new NotImplementedException();
        }
    }
}

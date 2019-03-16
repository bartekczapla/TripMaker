using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GoogleDirections;
using TripMaker.ExternalServices.Interfaces;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Core
{
    public class GoogleDirectionsInputFactory : IGoogleDirectionsInputFactory
    {


        //Required parameters: 
        //-key
        //-origin — The address, textual latitude/longitude value, or place ID from which you wish to calculate directions.
        // - destination — The address, textual latitude/longitude value, or place ID 

        //Optional parameters:
        //- language = {en, pl}
        //- mode {driving, walking, bicycling, transit(+departure_time, arrival_tie)}
        //- waypoints (intermediate locations) =via:lat%2Clng| =via:place_id:{id}|place_id:{id2}
        //- optimize waypoints( travelling salesperson problem) np &waypoints=optimize:true|Barossa+Valley,SA|Clare,SA
        // and return "waypoint_order": [ 3, 2, 0, 1 ]
        // -alternatives {true,false} alternative routes
        // - avoid {tolls|highways|ferries|indoor}
        // - unit={metirc}
        // - arrival_time/departure_time - Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC
        //mode is driving: You can specify the departure_time to receive a route and trip duration   that take traffic conditions into account. 
        // -traffic_model {best_guess ,pessimistic ,optimistic )
        // - transit_mode={bus,subway,train,tram,rail}
        // -transit_routing_preference {less_walking, fewer_transfers} 


        public GoogleDirectionsInput Create(string originId, string destinationId, LanguageType language, GoogleTravelMode mode)
        {
            return new GoogleDirectionsInput(originId, destinationId, mode, language);
        }


        public GoogleDirectionsInput Create(Location origin, Location destination, LanguageType language, GoogleTravelMode mode)
        {
            return new GoogleDirectionsInput(origin, destination, mode, language);
        }
    }
}

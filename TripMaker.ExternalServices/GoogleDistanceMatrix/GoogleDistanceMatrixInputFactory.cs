using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GoogleDistanceMatrix;
using TripMaker.ExternalServices.Interfaces.GoogleDistanceMatrix;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.GoogleDistanceMatrix
{
    public class GoogleDistanceMatrixInputFactory : IGoogleDistanceMatrixInputFactory
    {


        //Required parameters: 
        //-key
        //-origins={lat,lng}|{lat2,lng2}  origins=place_id:{id}|place_id:{id2}
        //-destinations={lat,lng}|{lat2,lng2}  destinations=place_id:{id}|place_id:{id2}

        //Optional parameters:
        //- language = {en, pl}
        //- mode {driving, walking, bicycling, transit(+departure_time, arrival_tie)}
        // - avoid {tolls|highways|ferries|indoor}
        // - unit={metirc}
        // - arrival_time/departure_time - Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC
        //mode is driving: You can specify the departure_time to receive a route and trip duration   that take traffic conditions into account. 
        // -traffic_model {best_guess ,pessimistic ,optimistic )
        // -transit_mode={bus,subway,train,tram,rail}
        // -transit_routing_preference {less_walking, fewer_transfers} 


        //Rows are ordered according to the values in the origin parameter of the request.Each row corresponds to an origin, and each element within that row corresponds to a pairing of the origin with a destination value.
        //Each row array contains one or more element entries, which in turn contain the information about a single origin-destination pairing.


        public GoogleDistanceMatrixInput Create(PlanForm planForm)
        {
            throw new NotImplementedException();
        }
    }
}

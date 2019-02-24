using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities
{
    public enum GoogleResultStatus
    {
        OK=1,
        UNKNOWN_ERROR=2,
        ZERO_RESULTS=3,
        OVER_QUERY_LIMIT=4,
        REQUEST_DENIED=5,
        INVALID_REQUEST=6,
        NOT_FOUND=7,
        MAX_WAYPOINTS_EXCEEDED=8,
        MAX_ROUTE_LENGTH_EXCEEDED=9, 
    }
}

//OK indicates that no errors occurred; the place was successfully detected and at least one result was returned.
//UNKNOWN_ERROR indicates a server-side error; trying again may be successful.
//ZERO_RESULTS indicates that the referenced location(placeid) was valid but no longer refers to a valid result.This may occur if the establishment is no longer in business.
//OVER_QUERY_LIMIT indicates any of the following:
//You have exceeded the QPS limits.
//Billing has not been enabled on your account.
//The monthly $200 credit, or a self-imposed usage cap, has been exceeded.
//The provided method of payment is no longer valid (for example, a credit card has expired).
//See the Maps FAQ for more information about how to resolve this error.

//REQUEST_DENIED indicates that your request was denied, generally because:
//The request is missing an API key.
//The key parameter is invalid.
//INVALID_REQUEST generally indicates that the query (placeid) is missing.
//NOT_FOUND indicates that the referenced location (placeid) was not found in the Places database.
//MAX_WAYPOINTS_EXCEEDED indicates that too many waypoints were provided in the request.For applications using the Directions API as a web service, or the directions service in the Maps JavaScript API, the maximum allowed number of waypoints is 23, plus the origin and destination,
//MAX_ROUTE_LENGTH_EXCEEDED indicates the requested route is too long and cannot be processed.This error occurs when more complex directions are returned.Try reducing the number of waypoints, turns, or instruction
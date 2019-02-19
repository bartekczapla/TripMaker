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
        NOT_FOUND=7
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
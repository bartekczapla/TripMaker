using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;

namespace TripMaker.ExternalServices.Helpers
{
    public static class InterpreteGoogleStatus
    {

        public static GoogleResultStatus Interprete(string status)
        {
            switch (status)
            {
                case "OK":
                    return GoogleResultStatus.OK;
                case "UNKNOWN_ERROR":
                    return GoogleResultStatus.UNKNOWN_ERROR;
                case "ZERO_RESULTS":
                    return GoogleResultStatus.ZERO_RESULTS;
                case "OVER_QUERY_LIMIT":
                    return GoogleResultStatus.OVER_QUERY_LIMIT;
                case "REQUEST_DENIED":
                    return GoogleResultStatus.REQUEST_DENIED;
                case "INVALID_REQUEST":
                    return GoogleResultStatus.INVALID_REQUEST;
                case "NOT_FOUND":
                    return GoogleResultStatus.NOT_FOUND;
                case "MAX_WAYPOINTS_EXCEEDED ":
                    return GoogleResultStatus.MAX_WAYPOINTS_EXCEEDED;
                case "MAX_ROUTE_LENGTH_EXCEEDED":
                    return GoogleResultStatus.MAX_ROUTE_LENGTH_EXCEEDED;
                default:
                    return GoogleResultStatus.NOT_FOUND;
            }
        }

        public static bool IsStatusOk(string status)
        {
            return Interprete(status) == GoogleResultStatus.OK;
        }

    }
}

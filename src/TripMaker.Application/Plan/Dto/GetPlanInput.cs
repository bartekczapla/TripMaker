using System;

namespace TripMaker.Plan
{
    public class GetPlanInput
    {
        public GooglePlaceInfo PlaceInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
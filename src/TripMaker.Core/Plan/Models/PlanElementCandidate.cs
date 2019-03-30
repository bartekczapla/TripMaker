using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.Plan.Models
{
    public class PlanElementCandidate
    {
        public string PlaceName { get; set; }

        public string PlaceId { get; set; }

        public Location Location { get; set; }

        public PlanElementType ElementType { get; set; }

        public double? Rating { get; set; }

        public TimeSpan Duration { get; set; }

        public PlanElementCandidate(string placeName, string placeId, Location location, PlanElementType elementType, TimeSpan duration,  double? rating=null)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            Location = location;
            ElementType = elementType;
            Rating = rating;
            Duration = duration;

        }

    }
}
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapTo(typeof(PlanAccomodation))]
    [AutoMapFrom(typeof(PlanAccomodation))]
    public class PlanAccomodationDto
    {
        public double Lat { get; set; }

        public double Lng { get; set; }

        public string PlaceId { get; set; }

        public string PlaceName { get; set; }

        public string FormattedAddress { get; set; }

        public decimal? Rating { get; set; }

        public decimal? TotalUserReviews { get; set; }

        public PlanAccomodationDto(double lat, double lng, string placeId, string placeName, string formattedAddress)
        {
            Lat = lat;
            Lng = lng;
            PlaceId = placeId;
            PlaceName = placeName;
            FormattedAddress = formattedAddress;
        }

        public PlanAccomodationDto(string placeId, string placeName)
        {
            PlaceId = placeId;
            PlaceName = placeName;

        }
    }
}

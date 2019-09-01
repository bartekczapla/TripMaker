using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanElement))]
    public class PlanElementDto : EntityDto
    {
        public  string PlaceName { get;  set; }

        public  string PlaceId { get;  set; }

        public string FormattedAddress { get; set; }

        public  double Lat { get;  set; }

        public  double Lng { get;  set; }

        public  int OrderNo { get;  set; }

        public  DateTime Start { get;  set; }

        public  DateTime End { get;  set; }

        public ICollection<PlanElementyTypeEntityDto> PlanElementTypes { get; set; }

        public ICollection<PlanElementOpeningHourEntityDto> OpeningHours { get; set; }

        public double? Rating { get;  set; }

        public decimal? Price { get; set; }

        public int? PlanId { get;  set; }

        public decimal? Popularity { get; set; }

        public PlanRouteDto EndingRoute { get; set; }

        public int ScorePosition { get; set; }

        public decimal NormalizedScore { get; set; }
    }
}

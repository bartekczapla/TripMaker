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

        public  double Lat { get;  set; }

        public  double Lng { get;  set; }

        public  int OrderNo { get;  set; }

        public  DateTime Start { get;  set; }

        public  DateTime End { get;  set; }

        public  PlanElementType ElementType { get;  set; }

        public  double? Rating { get;  set; }

        public  int? PlanId { get;  set; }


    }
}

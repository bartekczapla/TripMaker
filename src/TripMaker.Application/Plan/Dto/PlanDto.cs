using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Dto;

namespace TripMaker.Plan
{
    [AutoMapFrom(typeof(Plan))]
    public class PlanDto : EntityDto
    {
        public string Destination { get;  set; }

        public int? PlanFormId { get;  set; }

        public PlanFormDto PlanForm { get; set; }

        public PlanAccomodationDto Accomodation { get; set; }

        public  ICollection<PlanElementDto> Elements { get;  set; }

    }
}

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
        public string Name { get;  set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public int? PlanFormId { get;  set; }

        public decimal? Rating { get; set; }

        public decimal? TotalUserReviews { get; set; }

        public PlanFormDto PlanForm { get; set; }

        public PlanAccomodationDto PlanAccomodation { get; set; }

        public PlanFormWeightVectorDto PlanFormWeightVector { get; set; }

        public  ICollection<PlanElementDto> Elements { get;  set; }

        public string Photo { get; set; }

    }
}


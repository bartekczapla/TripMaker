using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanFormWeightVector))]
    public class PlanFormWeightVectorDto
    {
        public decimal Price { get; set; }

        public decimal Rating { get; set; }

        public decimal Distance { get; set; }

        public decimal Popularity { get; set; }

        public decimal Entertainment { get; set; }

        public decimal Relax { get; set; }

        public decimal Activity { get; set; }

        public decimal Culture { get; set; }

        public decimal Sightseeing { get; set; }

        public decimal Partying { get; set; }

        public  decimal Shopping { get; set; }
    }
}

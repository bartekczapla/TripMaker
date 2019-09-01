using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanElementyTypeEntity))]
    public class PlanElementyTypeEntityDto
    {
        public PlanElementType ElementType { get; set; }
    }
}

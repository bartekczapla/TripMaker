using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using TripMaker.Enums;
using TripMaker.Plan.Models;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("PlanElements")]
    public class PlanElement : Entity
    {
        public const int MaxTitleLength = 128;

        [MaxLength(MaxTitleLength)]
        public virtual string PlaceName { get; protected set; }

        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get; protected set; }

    
        public virtual double Lat { get; protected set; }


        public virtual double Lng { get; protected set; }

        [Required]
        public virtual int OrderNo { get; protected set; }

        [Required]
        public virtual DateTime Start { get; protected set; }

        [Required]
        public virtual DateTime End { get; protected set; }

        [Required]
        public virtual PlanElementType ElementType { get; protected set; }

        public virtual double? Rating { get; protected set; }

        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; protected set; }
        public virtual int? PlanId { get; protected set; }

        //[ForeignKey("StartPlanElementId")]
        //public virtual PlanRoute StartRoute{ get; protected set; }

        //[ForeignKey("EndPlanElementId")]
        //public virtual PlanRoute EndRoute { get; protected set; }


        public PlanElement(string placeName, string placeId,  double lat, double lng, int orderNo, DateTime start, DateTime end, PlanElementType elementType, double? rating=null)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            Lat = lat;
            Lng = lng;
            OrderNo = orderNo;
            Start = start;
            End = end;
            ElementType = elementType;
            Rating = rating;
        }

    }
}

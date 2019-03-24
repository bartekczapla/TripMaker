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
        public virtual string PlaceName { get;  set; }

        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get;  set; }

    
        public virtual double Lat { get;  set; }


        public virtual double Lng { get;  set; }

        [Required]
        public virtual int OrderNo { get;  set; }

        [Required]
        public virtual DateTime Start { get; set; }

        [Required]
        public virtual DateTime End { get;  set; }

        [Required]
        public virtual PlanElementType ElementType { get;  set; }

        public virtual double? Rating { get;  set; }

        [ForeignKey("PlanId")]
        public virtual Plan Plan { get;  set; }
        public virtual int? PlanId { get;  set; }

        [ForeignKey("StartingRouteId")]
        public virtual PlanRoute StartingRoute { get; set; }
        public virtual int? StartingRouteId { get; set; }

        [ForeignKey("EndingRouteId")]
        public virtual PlanRoute EndingRoute { get; set; }
        public virtual int? EndingRouteId { get; set; }

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

        public PlanElement(string placeName, string placeId, double lat, double lng, int orderNo, PlanElementType elementType, double? rating = null)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            Lat = lat;
            Lng = lng;
            OrderNo = orderNo;
            ElementType = elementType;
            Rating = rating;
            Start = new DateTime();
            End = new DateTime();
        }

        public void SetDate(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }



    }
}

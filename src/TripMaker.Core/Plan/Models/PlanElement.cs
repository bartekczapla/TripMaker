using System;
using System.Collections.Generic;
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

        [MaxLength(MaxTitleLength)]
        public virtual string FormattedAddress { get; set; }

        public virtual double Lat { get;  set; }

        public virtual double Lng { get;  set; }

        public virtual int OrderNo { get;  set; }

        public virtual DateTime Start { get; set; }

        public virtual DateTime End { get;  set; }

        [ForeignKey("PlanElementId")]
        public virtual ICollection<PlanElementyTypeEntity> PlanElementTypes { get; protected set; }

        [ForeignKey("PlanElementId")]
        public virtual ICollection<PlanElementOpeningHourEntity> OpeningHours { get; protected set; }

        public virtual decimal? Rating { get; set; }

        public virtual decimal? Price { get; set; }

        public virtual decimal? Popularity { get; set; }

        [ForeignKey("PlanId")]
        public virtual Plan Plan { get;  set; }
        public virtual int? PlanId { get;  set; }

        [ForeignKey("StartingRouteId")]
        public virtual PlanRoute StartingRoute { get; set; }
        public virtual int? StartingRouteId { get; set; }

        [ForeignKey("EndingRouteId")]
        public virtual PlanRoute EndingRoute { get; set; }
        public virtual int? EndingRouteId { get; set; }


        public virtual int ScorePosition { get; set; }

        public virtual decimal NormalizedScore { get; set; }


        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected PlanElement()
        {

        }

        public PlanElement(string placeName, string placeId, string formattedAddress, DateTime start, DateTime end, double lat, double lng, int orderNo, decimal? rating, decimal? price, decimal? popularity, PlanElementType type)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            Start = start;
            End = end;
            FormattedAddress = formattedAddress;
            Lat = lat;
            Lng = lng;
            OrderNo = orderNo;
            Rating = rating;
            Price = price;
            Popularity = popularity;
            ScorePosition = 0;
            NormalizedScore = 0;
            PlanElementTypes = new List<PlanElementyTypeEntity>();
            PlanElementTypes.Add(new PlanElementyTypeEntity(type));
            OpeningHours = new List<PlanElementOpeningHourEntity>();
        }


        public static PlanElement Create(DecisionRow row, int orderNo, DateTime start, DateTime end)
        {
            var element = new PlanElement
            {
                PlaceName = row.Candidate.PlaceName,
                PlaceId = row.Candidate.PlaceId,
                FormattedAddress = row.Candidate.FormattedAddress,
                Lat = row.Candidate.Location.lat,
                Lng = row.Candidate.Location.lng,
                OrderNo = orderNo,
                Rating = row.Candidate.Rating,
                Price = row.Candidate.Price,
                Popularity = row.Candidate.Popularity,
                ScorePosition=row.ScorePosition,
                NormalizedScore=row.NormalizedScore
            };

            element.PlanElementTypes = new List<PlanElementyTypeEntity>(row.Candidate.ElementTypes.Count);
            foreach (var e in row.Candidate.ElementTypes) element.PlanElementTypes.Add(new PlanElementyTypeEntity(e));

            element.OpeningHours = new List<PlanElementOpeningHourEntity>(row.Candidate.OpeningHours.Count);
            foreach (var e in row.Candidate.OpeningHours) element.OpeningHours.Add(new PlanElementOpeningHourEntity(e));

            return element;
        }

        public void SetDate(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        //public PlanElement(int orderNo, DateTime start, DateTime end)
        //{
        //    OrderNo = orderNo;
        //    Start = start;
        //    End = end;
        //}

        //public PlanElement(string placeName, string placeId,  double lat, double lng, int orderNo, DateTime start, DateTime end, PlanElementType elementType, double? rating=null)
        //{
        //    PlaceName = placeName;
        //    PlaceId = placeId;
        //    Lat = lat;
        //    Lng = lng;
        //    OrderNo = orderNo;
        //    Start = start;
        //    End = end;
        //    //ElementType = elementType;
        //   // Rating = rating;
        //}

        //public PlanElement(string placeName, string placeId, double lat, double lng, int orderNo, PlanElementType elementType, double? rating = null)
        //{
        //    PlaceName = placeName;
        //    PlaceId = placeId;
        //    Lat = lat;
        //    Lng = lng;
        //    OrderNo = orderNo;
        //    ElementType = elementType;
        //    Rating = rating;
        //    Start = new DateTime();
        //    End = new DateTime();
        //}



        public void UpdateDateTimeWithRouteDuration(TimeSpan routeDuration)
        {
            Start=Start.Add(routeDuration);
            End=End.Add(routeDuration);
        }

        //public void UpdateInformation(string placeName, string placeId, double lat, double lng, TimeSpan duration, PlanElementType elementType, double? rating = null)
        //{
        //    PlaceName = placeName;
        //    PlaceId = placeId;
        //    Lat = lat;
        //    Lng = lng;
        //    End=End.Add(duration);
        //    ElementType = elementType;
        //    Rating = rating;
        //}

    }
}

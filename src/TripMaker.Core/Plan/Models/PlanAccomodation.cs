using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TripMaker.Plan.Models
{
    [Table("PlanAccomodations")]
    public class PlanAccomodation : Entity
    {
        public const int MaxNameLength = 128;


        public virtual double Lat { get; set; }

        public virtual double Lng { get; set; }

        [MaxLength(MaxNameLength)]
        public string PlaceId { get; set; }

        [MaxLength(MaxNameLength)]
        public string PlaceName { get; set; }

        [MaxLength(MaxNameLength)]
        public string FormattedAddress { get; set; }

        //[ForeignKey("PlanFormId")]
        //public virtual PlanForm PlanForm { get; set; }
        //public virtual int PlanFormId { get; set; }


        public PlanAccomodation(double lat, double lng, string placeId, string placeName, string formattedAddress)
        {

            Lat = lat;
            Lng = lng;
            PlaceId = placeId;
            PlaceName = placeName;
            FormattedAddress = formattedAddress;
            
        }
    }
}
